using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinalBeesKilledStat : MonoBehaviour
{
    // The final bees killed stat will show up in the game over scene and the completed level scene
    TextMeshProUGUI finalBeesKilledStat;

    // Start is called before the first frame update
    void Start()
    {
        // Get the component of the TextMeshPro
        finalBeesKilledStat = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        // Update the final bees killed stat when the game is over (failed or completed)
        finalBeesKilledStat.text = "You killed " + Robot.beesKilled + " bees!";
        finalBeesKilledStat.fontSize = 20;
        finalBeesKilledStat.color = Color.white;
    }
}
