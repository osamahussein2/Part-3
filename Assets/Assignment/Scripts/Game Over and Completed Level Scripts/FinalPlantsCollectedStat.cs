using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinalPlantsCollectedStat : MonoBehaviour
{
    // The final bees killed stat will show up in the game over scene and the completed level scene
    TextMeshProUGUI finalPlantsCollectedStat;

    // Start is called before the first frame update
    void Start()
    {
        // Get the component of the TextMeshPro
        finalPlantsCollectedStat = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        // Update the final plants collected stat when the game is over (failed or completed)
        finalPlantsCollectedStat.text = "You collected " + Robot.plantsCollected + " plants!";
        finalPlantsCollectedStat.fontSize = 20;
        finalPlantsCollectedStat.color = Color.white;
    }
}
