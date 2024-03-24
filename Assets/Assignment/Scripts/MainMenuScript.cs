using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void OnClickPlayButton()
    {
        // When the player clicks the play button on the main menu, take them to the playing game scene
        SceneManager.LoadScene("Flying Robot");
    }

    public void OnClickHowToPlayButton()
    {
        // When the player clicks the how to play button on the main menu, take them to the how to play scene
        SceneManager.LoadScene("How to Play");
    }

    public void OnClickBackButton()
    {
        // When the player clicks the back button on the how to play menu, take them back to the main menu
        SceneManager.LoadScene("Main Menu");
    }
}
