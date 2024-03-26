using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ParentBee : MonoBehaviour
{
    // Make these variables protected to use inside the child bee classes of this ParentBee class
    protected Rigidbody2D rigidbody;
    protected Vector2 movement;
    protected float speed;

    // Make these 2 colliders public to trigger different events for the player
    public Collider2D collider1;
    public Collider2D collider2;

    // Start is called before the first frame update
    void Start()
    {
        InitializeVariables(); // Call this function in Start
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        MoveBee();// Call this function in FixedUpdate
    }

    protected virtual void InitializeVariables()
    {
        // Initialize the rigidbody component of the parent bee
        rigidbody = GetComponent<Rigidbody2D>();

        // Set the movement and speed to 1
        movement = new Vector2(1.0f, 0.0f);
        speed = 1.0f;
    }

    protected virtual void MoveBee()
    {
        // If the rigidbody of this bee is close to left of the jumping platform, move the bee the other way
        if (rigidbody.position.x <= -6.19f)
        {
            movement = new Vector2(1.0f, 0.0f);
        }

        // If the rigidbody of this bee is close to right of the jumping platform, move the bee the other way
        if (rigidbody.position.x >= -4.36f)
        {
            movement = new Vector2(-1.0f, 0.0f);
        }

        // Move the parent bee using its rigidbody
        rigidbody.MovePosition(rigidbody.position + movement * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /* If collider1 and collider2 are not null, trigger these events below so that Unity won't throw an error
        during runtime saying its null */
        if (collider1 != null && collider2 != null)
        {
            /* If the player didn't jump on the bee's head or wings while colliding with the bee, then don't
            increment the bees killed counter for the player and load the game over scene for the player */
            if (collider1.IsTouching(Robot.playerRobot.GetComponent<Collider2D>()))
            {
                Robot.beesKilled += 0;
                SceneManager.LoadScene("Game Over");
            }

            /* If the player did jump on the bee's head or wings while colliding with the bee with either
            their left leg or right leg, then destroy the bee and add bee kills by 1 */
            if (collider2.IsTouching(Robot.leftLeg.GetComponent<Collider2D>()) ||
                collider2.IsTouching(Robot.rightLeg.GetComponent<Collider2D>()))
            {
                Destroy(gameObject);
                Robot.beesKilled += 1;
            }
        }
    }
}
