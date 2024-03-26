using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant8 : Plant
{
    // Plant 8 object
    public static GameObject plant8;

    public static bool collectedPlant8; // If the player collected the plant or not


    // Start is called before the first frame update
    protected override void Start()
    {
        // Find Plant 8
        plant8 = GameObject.Find("Plant 8");

        // Set this to false because the player hasn't collected the plant yet
        collectedPlant8 = false;
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        Robot.CollectPlant8(collision); // Call the collect plant 8 function for Plant 8
    }
}
