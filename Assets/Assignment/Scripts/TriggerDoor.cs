using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class TriggerDoor : MonoBehaviour
{
    /* We will need a reference to the red and green doors inside the inspector for making them visible or not
    visible in the scene */
    public GameObject redDoor;
    public GameObject greenDoor;

    // Get an array of bee gameObjects and use them inside the inspector for checking if the bees are destroyed
    public GameObject[] bees; 

    // Start is called before the first frame update
    void Start()
    {
        // We want this to be active first because the player hasn't killed all of the bees yet
        redDoor.SetActive(true);

        // We don't want this to be active until the player has killed all of the bees
        greenDoor.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // If at least 1 bee is not destroyed, don't make the green door visible to the player
        if (!bees[0].IsDestroyed() || !bees[1].IsDestroyed() || !bees[2].IsDestroyed() || !bees[3].IsDestroyed()
            || !bees[4].IsDestroyed() || !bees[5].IsDestroyed() || !bees[6].IsDestroyed() || !bees[7].IsDestroyed())
        {
            redDoor.SetActive(true);
            greenDoor.SetActive(false);
        }

        // Else if the player kills and destroys all the bees, make the green door visible to the player
        else if (bees[0].IsDestroyed() && bees[1].IsDestroyed() && bees[2].IsDestroyed() && bees[3].IsDestroyed()
            && bees[4].IsDestroyed() && bees[5].IsDestroyed() && bees[6].IsDestroyed() && bees[7].IsDestroyed())
        {
            redDoor.SetActive(false);
            greenDoor.SetActive(true);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // As long as the red door is visible, tell the player to go back and kill the bees when they reach the door
        if(redDoor.activeInHierarchy && !greenDoor.activeInHierarchy &&
            collision.gameObject.name == "Robot")
        {
            Debug.Log("Hey, you haven't killed all the bees. Go back there and kill them now!");
        }

        // Once the green door is visible, show the completed screen to the player when they reach the door
        if (!redDoor.activeInHierarchy && greenDoor.activeInHierarchy && 
            collision.gameObject.name == "Robot")
        {
            SceneManager.LoadScene("Completed Screen");
        }
    }
}
