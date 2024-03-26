using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant5 : Plant
{
    // Plant 5 object
    public static GameObject plant5;

    public static bool collectedPlant5; // If the player collected the plant or not

    // Start is called before the first frame update
    protected override void Start()
    {
        // Find Plant 5
        plant5 = GameObject.Find("Plant 5");

        // Set this to false because the player hasn't collected the plant yet
        collectedPlant5 = false;
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        Robot.CollectPlant5(collision); // Call the collect plant 5 function for Plant 5
    }
}
