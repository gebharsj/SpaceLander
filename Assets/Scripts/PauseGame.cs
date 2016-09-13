using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour {

    public GameObject pauseMenu;
    bool paused = false;

    void Start()
    {
        Time.timeScale = 1;
    }

    void Update()
    {
        //toggles the pause menu gameobject
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            paused = togglePause();
            if (paused)
            {
                pauseMenu.SetActive(true);
            }
            else
            {
                pauseMenu.SetActive(false);
            }
        }
    }

    bool togglePause()      //Sets the time scale to pause the game
    {
        if (Time.timeScale == 0) 
        {
            Time.timeScale = 1;     //unpauses game
            return (false);
        }
        else
        {
            Time.timeScale = 0;     //pauses game
            return (true);
        }
    }
}