using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour {

    [Tooltip("The pause menu")]
    public GameObject pauseMenu;
    [Tooltip("The pause button")]
    public GameObject pauseButton;

    bool paused = false;

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

    bool TogglePause()                  //Sets the time scale to pause the game
    {
        if (Time.timeScale == 0) 
        {
            Time.timeScale = 1;         //unpauses game
            return (false);
        }
        else
        {
            Time.timeScale = 0;         //pauses game
            return (true);
        }
    }

    public void ToggleMenu()            //Activates/deactivates UI elements based on whether or not the game is paused
    {
        paused = TogglePause();
        pauseButton.SetActive(!paused);
        pauseMenu.SetActive(paused);
    }
}