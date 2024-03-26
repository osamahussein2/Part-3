using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant6 : Plant
{
    // Plant 6 object
    public static GameObject plant6;

    public static bool collectedPlant6; // If the player collected the plant or not

    // Start is called before the first frame update
    protected override void Start()
    {
        // Find Plant 6
        plant6 = GameObject.Find("Plant 6");

        // Set this to false because the player hasn't collected the plant yet
        collectedPlant6 = false;
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        Robot.CollectPlant6(collision); // Call the collect plant 6 function for Plant 6
    }
}
