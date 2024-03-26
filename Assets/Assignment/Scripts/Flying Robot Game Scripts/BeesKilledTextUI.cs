using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BeesKilledTextUI : MonoBehaviour
{
    // Create a TextMeshPro component for bees killed
    TextMeshProUGUI beesKilledTextUI;

    // Start is called before the first frame update
    void Start()
    {
        // Get the component of bees killed text
        beesKilledTextUI = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        // Display the bees killed text along with the bees killed integer from the Robot class
        beesKilledTextUI.text = "Bees killed: " + Robot.beesKilled;
        beesKilledTextUI.color = Color.red; // Make the text red
        beesKilledTextUI.fontSize = 18; // Make the font size 18
    }
}
