using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BasicMenuButton : MonoBehaviour
{
    public float waitTime = 2f;
    public void LoadLevel(string levelName) // choose a level to load
    {
        SceneManager.LoadScene(levelName);
    }

    public void RestartLevel() //restart the current level
    {
        BasicUtilities.RestartLevel();
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

    public void DelayedLoadLevel(string levelName) // choose a level to load
    {
        StartCoroutine(DelayLoadScene(levelName, waitTime));
        //SceneManager.LoadScene(levelName);
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(2f);
    }

    IEnumerator Delay(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }

    IEnumerator DelayLoadScene(string sceneName, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(sceneName);
    }
}