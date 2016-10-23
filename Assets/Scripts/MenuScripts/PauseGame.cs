using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour {

    [Tooltip("The pause menu")]
    public GameObject pauseMenu;
    [Tooltip("The pause button")]
    public GameObject pauseButton;

    static bool paused = false;
    public static bool popUpActivated = false;

    void Start()
    {
        if(pauseMenu == null)
        {
            Debug.LogError("PauseMenu has not been set!");
        }

        if (pauseButton == null)
        {
            Debug.LogError("PauseButton has not been set!");
        }
    }

    void TogglePause()                  //Sets the time scale to pause the game
    {
        if (!popUpActivated)            //is the popup is not actived, work normally
        {
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1;         //unpauses game
            }
            else
            {
                Time.timeScale = 0;         //pauses game
            }
        }
        else
            Time.timeScale = 0;         // don't unpause if the popup is up
    }

    public void ToggleMenu()            //Activates/deactivates UI elements based on whether or not the game is paused
    {
        TogglePause();
        paused = !paused;
        pauseButton.SetActive(!paused);
        pauseMenu.SetActive(paused);
    }
}