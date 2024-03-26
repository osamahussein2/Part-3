using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant4 : Plant
{
    // Plant 4 object
    public static GameObject plant4;

    public static bool collectedPlant4; // If the player collected the plant or not

    // Start is called before the first frame update
    protected override void Start()
    {
        // Find Plant 4
        plant4 = GameObject.Find("Plant 4");

        // Set this to false because the player hasn't collected the plant yet
        collectedPlant4 = false;
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        Robot.CollectPlant4(collision); // Call the collect plant 4 function for Plant 4
    }
}
