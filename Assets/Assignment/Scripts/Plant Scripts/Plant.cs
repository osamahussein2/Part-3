using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    // Plant 1 object
    public static GameObject plant1;

    public static bool collectedPlant1; // If the player collected the plant or not

    // Start is called before the first frame update
    protected virtual void Start()
    {
        // Find Plant 1
        plant1 = GameObject.Find("Plant 1");

        // Set this to false because the player hasn't collected the plant yet
        collectedPlant1 = false;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        Robot.CollectPlant1(collision); // Call the collect plant 1 function for Plant 1
    }
}
