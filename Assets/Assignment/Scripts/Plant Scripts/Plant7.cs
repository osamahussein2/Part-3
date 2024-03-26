using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant7 : Plant
{
    // Plant 7 object
    public static GameObject plant7;

    public static bool collectedPlant7; // If the player collected the plant or not

    // Start is called before the first frame update
    protected override void Start()
    {
        // Find Plant 7
        plant7 = GameObject.Find("Plant 7");

        // Set this to false because the player hasn't collected the plant yet
        collectedPlant7 = false;
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        Robot.CollectPlant7(collision); // Call the collect plant 7 function for Plant 7
    }
}
