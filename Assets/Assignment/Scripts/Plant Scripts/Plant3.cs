using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant3 : Plant
{
    // Plant 3 object
    public static GameObject plant3;

    public static bool collectedPlant3; // If the player collected the plant or not

    // Start is called before the first frame update
    protected override void Start()
    {
        // Find Plant 3
        plant3 = GameObject.Find("Plant 3");

        // Set this to false because the player hasn't collected the plant yet
        collectedPlant3 = false;
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        Robot.CollectPlant3(collision); // Call the collect plant 3 function for Plant 3
    }
}
