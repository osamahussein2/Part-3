using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    // Create a rigidbody2D for moving physics and the jumping lerp to take place
    Rigidbody2D playerRigidbody;

    // Make the player speed 5 so that the player can move faster
    float speed = 5.0f;

    // This is used for lerping the jump physics when the player presses the SPACE key
    Vector2 jump;

    // This will evaluate the timer for the animation curve
    float jumpAnimationTimer;

    // Create an animation curve for lerping the jumping rigidbody animation
    public AnimationCurve jumpAnimation;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the player rigidbody2D component
        playerRigidbody = GetComponent<Rigidbody2D>();

        // Initialize the jump vector
        jump = new Vector2(0.0f, 0.8f); // 0.8 prevents the player from jumping through the platforms constantly

        // Tell the player what key to press to jump
        Debug.Log("Hold down the SPACE key to jump!");
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
}
