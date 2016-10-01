using UnityEngine;
using UnityEngine.SceneManagement;

public class BasicMenuButton : MonoBehaviour
{
    public void LoadLevel(string levelName) // choose a level to load
    {
        if (levelName.Equals("WinScreen")) //if the player is going to the winscreen
        {
            //------------Prevents the Player from Not Grabbing Num Of Platforms through Pause Menu-----------
            WinScreenManager.correctAnswer += GameObject.FindGameObjectWithTag("GameManager").GetComponent<QPopUpManager>().correctlyAnswered; //adds correct answer
            WinScreenManager.incorrectAnswer += GameObject.FindGameObjectWithTag("GameManager").GetComponent<QPopUpManager>().incorrectlyAnswered;  //adds incorrect answer
            Answered.SendStatsToEndScreen();    //does the remainder to the needed data from Answered
        }
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