using UnityEngine;
using UnityEngine.SceneManagement;

public class BasicMenuButton : MonoBehaviour
{
    public void LoadLevel(string levelName) // choose a level to load
    {
        SceneManager.LoadScene(levelName);
    }

    public void RestartLevel() //restart the current level
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public void ToggleObject(GameObject turnOff, GameObject turnOn) //toggle an object on and another off
    {
        turnOff.SetActive(false);
        turnOn.SetActive(true);
    }

    public void ExitGame() //exit game
    {
        Application.Quit();
    }
}