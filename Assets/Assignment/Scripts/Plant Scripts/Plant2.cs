using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant2 : Plant
{
    // Plant 2 object
    public static GameObject plant2;

    public static bool collectedPlant2; // If the player collected the plant or not

    // Start is called before the first frame update
    protected override void Start()
    {
        // Find Plant 2
        plant2 = GameObject.Find("Plant 2");

        // Set this to false because the player hasn't collected the plant yet
        collectedPlant2 = false;
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        Robot.CollectPlant2(collision); // Call the collect plant 2 function for Plant 2
    }
}
