using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildBee2 : ParentBee
{
    protected override void InitializeVariables()
    {
        // Without this, the child bee's rigidbody would be undefined
        rigidbody = GetComponent<Rigidbody2D>();

        // Make the movement and speed of this bee different from other bees, including the parent bee
        movement = new Vector2(1.6f, 0.0f);
        speed = 1.6f;
    }

    protected override void MoveBee()
    {
        // If the rigidbody of this bee is close to left of the jumping platform, move the bee the other way
        if (rigidbody.position.x <= -8.14f)
        {
            movement = new Vector2(1.6f, 0.0f);
        }

        // If the rigidbody of this bee is close to right of the jumping platform, move the bee the other way
        if (rigidbody.position.x >= -6.21f)
        {
            movement = new Vector2(-1.6f, 0.0f);
        }

        // Move the child bee using its rigidbody
        rigidbody.MovePosition(rigidbody.position + movement * speed * Time.deltaTime);
    }
}