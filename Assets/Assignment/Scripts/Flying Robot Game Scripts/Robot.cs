using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    // Create a rigidbody2D for moving physics and the jumping lerp to take place
    Rigidbody2D playerRigidbody;

    // Make the player speed 5 so that the player can move faster
    private float speed = 5.0f;

    /* Make the bees killed int a static variable so that this variable can be used inside the ParentBee class and
    the text UI class */
    public static int beesKilled;

    /* Create the plants collected int so that this variable can be used inside the static function of CollectPlants()
    and call it inside the plant class and the text UI class */
    public static int plantsCollected;

    // This is used for lerping the jump physics when the player presses the SPACE key
    private Vector2 jump;

    // This will evaluate the timer for the animation curve
    float jumpAnimationTimer;

    // Create an animation curve for lerping the jumping rigidbody animation
    public AnimationCurve jumpAnimation;

    // Create a game object of left hand and right hand
    public static GameObject leftHand;
    public static GameObject rightHand;

    // Create a game object of left leg and right leg
    public static GameObject leftLeg;
    public static GameObject rightLeg;

    // Create a game object of player robot to use it inside the ParentBee class
    public static GameObject playerRobot;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the player rigidbody2D component
        playerRigidbody = GetComponent<Rigidbody2D>();

        // Find the robot game object
        playerRobot = GameObject.Find("Robot");

        // Find the left hand and right hand game objects
        leftHand = GameObject.Find("Left hand");
        rightHand = GameObject.Find("Right hand");

        // Find the left leg and right leg game objects
        leftLeg = GameObject.Find("Left leg");
        rightLeg = GameObject.Find("Right leg");

        // Initialize the jump vector
        jump = new Vector2(0.0f, 0.8f); // 0.8 prevents the player from jumping through the platforms constantly

        beesKilled = 0; // Set it to 0 at start of the Flying Robot game
        plantsCollected = 0; // Set it to 0 at start of the Flying Robot game
    }

    // Update is called once per frame
    void Update()
    {
        // Increment the jump animation timer by deltaTime and create a local float for evaluating the animation curve
        jumpAnimationTimer += Time.deltaTime;
        float jumpTime = jumpAnimation.Evaluate(jumpAnimationTimer);

        // If the jump animation timer is greater than 1, make it 0 to continue lerping the jump physics
        if (jumpAnimationTimer > 1)
        {
            jumpAnimationTimer = 0;
        }

        // If the player presses SPACE, trigger the jump lerping animation physics
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRigidbody.position = Vector2.Lerp(playerRigidbody.position, playerRigidbody.position + jump, jumpTime);
        }
    }

    void FixedUpdate()
    {
        // The player will press the left and right arrow keys or 'A' and 'D' keys for moving left and right
        Vector2 horizontalMovement = new Vector2(Input.GetAxis("Horizontal"), 0.0f);

        /* If the player is at the left side of the screen, make it equal to that position so that the player
        doesn't go offscreen */
        if (playerRigidbody.position.x <= -9.39f)
        {
            playerRigidbody.position = new Vector2(-9.39f, playerRigidbody.position.y);
        }

        /* If the player is at the right side of the screen, make it equal to that position so that the player
        doesn't go offscreen */
        if (playerRigidbody.position.x >= 9.47f)
        {
            playerRigidbody.position = new Vector2(9.47f, playerRigidbody.position.y);
        }

        /* If the player is above the screen, make it equal to that position so that the player
        doesn't go offscreen */
        if (playerRigidbody.position.y <= -4.3f)
        {
            playerRigidbody.position = new Vector2(playerRigidbody.position.x, -4.3f);
        }

        /* If the player is below the screen, make it equal to that position so that the player
        doesn't go offscreen */
        if (playerRigidbody.position.y >= 4.3f)
        {
            playerRigidbody.position = new Vector2(playerRigidbody.position.x, 4.3f);
        }

        // Move the player's rigidbody on fixed update plus the horizontal movement that includes keyboard input
        playerRigidbody.MovePosition(playerRigidbody.position + horizontalMovement * speed * Time.deltaTime);
    }

    // Make this public function a static void to inside it inside the Plant's OnTriggerEnter2D function
    public static void CollectPlant1(Collider2D collider)
    {
        // If the player's left hand collides with Plant 1, collect the plant with the player's left hand
        if (collider.gameObject == leftHand)
        {
            plantsCollected += 1; // Increase plants collected score

            Plant.collectedPlant1 = true; // Set collected plant 1 to true

            // Make Plant 1 the child of player's left hand
            Plant.plant1.transform.SetParent(leftHand.transform, true);

            /* Make Plant 1 local position equal to left hand's local position minus left hand's local position
            to make the plant stick to the player's left hand */
            Plant.plant1.transform.localPosition = leftHand.transform.localPosition - 
                leftHand.transform.localPosition;
        }

        // If the player's right hand collides with Plant 1, collect the plant with the player's right hand
        if (collider.gameObject == rightHand)
        {
            plantsCollected += 1; // Increase plants collected score

            Plant.collectedPlant1 = true; // Set collected plant 1 to true

            // Make Plant 1 the child of player's right hand
            Plant.plant1.transform.SetParent(rightHand.transform, true);

            /* Make Plant 1 local position equal to right hand's local position minus right hand's local position
            to make the plant stick to the player's right hand */
            Plant.plant1.transform.localPosition = rightHand.transform.localPosition - 
                rightHand.transform.localPosition;
        }
    }

    // Make this public function a static void to inside it inside the Plant's OnTriggerEnter2D function
    public static void CollectPlant2(Collider2D collider)
    {
        // If the player's left hand collides with Plant 2, collect the plant with the player's left hand
        if (collider.gameObject == leftHand)
        {
            plantsCollected += 1; // Increase plants collected score

            Plant2.collectedPlant2 = true; // Set collected plant 2 to true

            // Make Plant 2 the child of player's left hand
            Plant2.plant2.transform.SetParent(leftHand.transform, true);

            /* Make Plant 2 local position equal to left hand's local position minus left hand's local position
            to make the plant stick to the player's left hand */
            Plant2.plant2.transform.localPosition = leftHand.transform.localPosition -
                leftHand.transform.localPosition;
        }

        // If the player's right hand collides with Plant 2, collect the plant with the player's right hand
        if (collider.gameObject == rightHand)
        {
            plantsCollected += 1; // Increase plants collected score

            Plant2.collectedPlant2 = true; // Set collected plant 2 to true

            // Make Plant 2 the child of player's right hand
            Plant2.plant2.transform.SetParent(rightHand.transform, true);

            /* Make Plant 2 local position equal to right hand's local position minus right hand's local position
            to make the plant stick to the player's right hand */
            Plant2.plant2.transform.localPosition = rightHand.transform.localPosition -
                rightHand.transform.localPosition;
        }
    }

    // Make this public function a static void to inside it inside the Plant's OnTriggerEnter2D function
    public static void CollectPlant3(Collider2D collider)
    {
        // If the player's left hand collides with Plant 3, collect the plant with the player's left hand
        if (collider.gameObject == leftHand)
        {
            plantsCollected += 1; // Increase plants collected score

            Plant3.collectedPlant3 = true; // Set collected plant 3 to true

            // Make Plant 3 the child of player's left hand
            Plant3.plant3.transform.SetParent(leftHand.transform, true);

            /* Make Plant 3 local position equal to left hand's local position minus left hand's local position
            to make the plant stick to the player's left hand */
            Plant3.plant3.transform.localPosition = leftHand.transform.localPosition -
                leftHand.transform.localPosition;
        }

        // If the player's right hand collides with Plant 3, collect the plant with the player's right hand
        if (collider.gameObject == rightHand)
        {
            plantsCollected += 1; // Increase plants collected score

            Plant3.collectedPlant3 = true; // Set collected plant 3 to true

            // Make Plant 3 the child of player's right hand
            Plant3.plant3.transform.SetParent(rightHand.transform, true);

            /* Make Plant 3 local position equal to right hand's local position minus right hand's local position
            to make the plant stick to the player's right hand */
            Plant3.plant3.transform.localPosition = rightHand.transform.localPosition -
                rightHand.transform.localPosition;
        }
    }

    // Make this public function a static void to inside it inside the Plant's OnTriggerEnter2D function
    public static void CollectPlant4(Collider2D collider)
    {
        // If the player's left hand collides with Plant 4, collect the plant with the player's left hand
        if (collider.gameObject == leftHand)
        {
            plantsCollected += 1; // Increase plants collected score

            Plant4.collectedPlant4 = true; // Set collected plant 4 to true

            // Make Plant 4 the child of player's left hand
            Plant4.plant4.transform.SetParent(leftHand.transform, true);

            /* Make Plant 4 local position equal to left hand's local position minus left hand's local position
            to make the plant stick to the player's left hand */
            Plant4.plant4.transform.localPosition = leftHand.transform.localPosition -
                leftHand.transform.localPosition;
        }

        // If the player's right hand collides with Plant 4, collect the plant with the player's right hand
        if (collider.gameObject == rightHand)
        {
            plantsCollected += 1; // Increase plants collected score

            Plant4.collectedPlant4 = true; // Set collected plant 4 to true

            // Make Plant 4 the child of player's right hand
            Plant4.plant4.transform.SetParent(rightHand.transform, true);

            /* Make Plant 4 local position equal to right hand's local position minus right hand's local position
            to make the plant stick to the player's right hand */
            Plant4.plant4.transform.localPosition = rightHand.transform.localPosition -
                rightHand.transform.localPosition;
        }
    }

    // Make this public function a static void to inside it inside the Plant's OnTriggerEnter2D function
    public static void CollectPlant5(Collider2D collider)
    {
        // If the player's left hand collides with Plant 5, collect the plant with the player's left hand
        if (collider.gameObject == leftHand)
        {
            plantsCollected += 1; // Increase plants collected score

            Plant5.collectedPlant5 = true; // Set collected plant 5 to true

            // Make Plant 5 the child of player's left hand
            Plant5.plant5.transform.SetParent(leftHand.transform, true);

            /* Make Plant 5 local position equal to left hand's local position minus left hand's local position
            to make the plant stick to the player's left hand */
            Plant5.plant5.transform.localPosition = leftHand.transform.localPosition -
                leftHand.transform.localPosition;
        }

        // If the player's right hand collides with Plant 5, collect the plant with the player's right hand
        if (collider.gameObject == rightHand)
        {
            plantsCollected += 1; // Increase plants collected score

            Plant5.collectedPlant5 = true; // Set collected plant 5 to true

            // Make Plant 5 the child of player's right hand
            Plant5.plant5.transform.SetParent(rightHand.transform, true);

            /* Make Plant 5 local position equal to right hand's local position minus right hand's local position
            to make the plant stick to the player's right hand */
            Plant5.plant5.transform.localPosition = rightHand.transform.localPosition -
                rightHand.transform.localPosition;
        }
    }

    // Make this public function a static void to inside it inside the Plant's OnTriggerEnter2D function
    public static void CollectPlant6(Collider2D collider)
    {
        // If the player's left hand collides with Plant 6, collect the plant with the player's left hand
        if (collider.gameObject == leftHand)
        {
            plantsCollected += 1; // Increase plants collected score

            Plant6.collectedPlant6 = true; // Set collected plant 6 to true

            // Make Plant 6 the child of player's left hand
            Plant6.plant6.transform.SetParent(leftHand.transform, true);

            /* Make Plant 6 local position equal to left hand's local position minus left hand's local position
            to make the plant stick to the player's left hand */
            Plant6.plant6.transform.localPosition = leftHand.transform.localPosition -
                leftHand.transform.localPosition;
        }

        // If the player's right hand collides with Plant 6, collect the plant with the player's right hand
        if (collider.gameObject == rightHand)
        {
            plantsCollected += 1; // Increase plants collected score

            Plant6.collectedPlant6 = true; // Set collected plant 6 to true

            // Make Plant 6 the child of player's right hand
            Plant6.plant6.transform.SetParent(rightHand.transform, true);

            /* Make Plant 6 local position equal to right hand's local position minus right hand's local position
            to make the plant stick to the player's right hand */
            Plant6.plant6.transform.localPosition = rightHand.transform.localPosition -
                rightHand.transform.localPosition;
        }
    }

    // Make this public function a static void to inside it inside the Plant's OnTriggerEnter2D function
    public static void CollectPlant7(Collider2D collider)
    {
        // If the player's left hand collides with Plant 7, collect the plant with the player's left hand
        if (collider.gameObject == leftHand)
        {
            plantsCollected += 1; // Increase plants collected score

            Plant7.collectedPlant7 = true; // Set collected plant 7 to true

            // Make Plant 7 the child of player's left hand
            Plant7.plant7.transform.SetParent(leftHand.transform, true);

            /* Make Plant 7 local position equal to left hand's local position minus left hand's local position
            to make the plant stick to the player's left hand */
            Plant7.plant7.transform.localPosition = leftHand.transform.localPosition -
                leftHand.transform.localPosition;
        }

        // If the player's right hand collides with Plant 7, collect the plant with the player's right hand
        if (collider.gameObject == rightHand)
        {
            plantsCollected += 1; // Increase plants collected score

            Plant7.collectedPlant7 = true; // Set collected plant 7 to true

            // Make Plant 7 the child of player's right hand
            Plant7.plant7.transform.SetParent(rightHand.transform, true);

            /* Make Plant 7 local position equal to right hand's local position minus right hand's local position
            to make the plant stick to the player's right hand */
            Plant7.plant7.transform.localPosition = rightHand.transform.localPosition -
                rightHand.transform.localPosition;
        }
    }

    // Make this public function a static void to inside it inside the Plant's OnTriggerEnter2D function
    public static void CollectPlant8(Collider2D collider)
    {
        // If the player's left hand collides with Plant 8, collect the plant with the player's left hand
        if (collider.gameObject == leftHand)
        {
            plantsCollected += 1; // Increase plants collected score

            Plant8.collectedPlant8 = true; // Set collected plant 8 to true

            // Make Plant 8 the child of player's left hand
            Plant8.plant8.transform.SetParent(leftHand.transform, true);

            /* Make Plant 8 local position equal to left hand's local position minus left hand's local position
            to make the plant stick to the player's left hand */
            Plant8.plant8.transform.localPosition = leftHand.transform.localPosition -
                leftHand.transform.localPosition;
        }

        // If the player's right hand collides with Plant 8, collect the plant with the player's right hand
        if (collider.gameObject == rightHand)
        {
            plantsCollected += 1; // Increase plants collected score

            Plant8.collectedPlant8 = true; // Set collected plant 8 to true

            // Make Plant 8 the child of player's right hand
            Plant8.plant8.transform.SetParent(rightHand.transform, true);

            /* Make Plant 8 local position equal to right hand's local position minus right hand's local position
            to make the plant stick to the player's right hand */
            Plant8.plant8.transform.localPosition = rightHand.transform.localPosition -
                rightHand.transform.localPosition;
        }
    }
}
