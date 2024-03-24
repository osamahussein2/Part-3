using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// ButtonScript is only for the game over screen and completed screen scenes (doesn't include main menu)
// The main menu will have a seperate script since I will create the how-to-play scene
public class ButtonScript : MonoBehaviour
{
    public void OnClickRestartButton()
    {
        // If the player clicks the restart button, take them back to the Flying Robot scene to try again
        SceneManager.LoadScene("Flying Robot");
    }

    public void OnClickQuitButton()
    {
        // If the player clicks on the quit button, take them to the main menu
        SceneManager.LoadScene("Main Menu");
    }
}
