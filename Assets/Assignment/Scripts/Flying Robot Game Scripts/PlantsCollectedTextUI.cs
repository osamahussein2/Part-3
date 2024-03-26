using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlantsCollectedTextUI : MonoBehaviour
{
    // Create a TextMeshPro component for plants collected
    TextMeshProUGUI plantsCollectedTextUI;

    // Start is called before the first frame update
    void Start()
    {
        // Get the component of plants collected text
        plantsCollectedTextUI = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        // Display the plants collected text along with the plants collected integer from the Robot class
        plantsCollectedTextUI.text = "Plants collected: " + Robot.plantsCollected;
        plantsCollectedTextUI.color = Color.green; // Make the text green
        plantsCollectedTextUI.fontSize = 18; // Make the font size 18
    }
}
