using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Answered : MonoBehaviour {

    [Tooltip("The amount of time you wait to see correct/incorrect answers")]
    public float waitTime = 2;                                
    bool isWaiting;                                             //generic bool to stop the Coroutine
    private QPopUpManager question;                            // Reference the Question pop up script

    void Start()
    {
        question = GameObject.FindGameObjectWithTag("GameManager").GetComponent<QPopUpManager>(); //grabs the question pop-up script

        if (question == null)
            Debug.LogError("There is no QPopUpManager on gameManager or " + GameObject.FindGameObjectWithTag("GameManager") + "");

    }

    public void Answer()
    {
        question.CheckIfCorrect(this.GetComponentInChildren<Text>().text);

        StartCoroutine(WaitAnswer());
    }

    IEnumerator WaitAnswer()
    {
        if (!isWaiting)
        {
            isWaiting = true;
            yield return new WaitForSecondsRealtime(waitTime);                  // waits for the right time
            question.WasAnswered();                                             // Enable the next buttons
            question.ResetColor();                                              // reset colors
            isWaiting = false;
        }
    }

    public void ContinuePlaying() {
        Time.timeScale = 1;                                                 // Gravity, force, and controls can be applied.
        for (int i = 0; i < question.answers.Length; i++) {
            question.answers[i].SetActive(true);                            // Once answered, set all buttons active for the next question.
        }
        for (int i = 0; i < question.answeredButtons.Length; i++) {
            question.answeredButtons[i].SetActive(false);                   // Once answered, set the buttons for after are disabled.
        }
        gameObject.transform.parent.gameObject.SetActive(false);            // Set the Pop up inactive
    }

    public void NextLevel()
    {
        PopUp.secondTime = false;
        PointsManager.savedPoints = PointsManager.totalPoints;              //saves the points, can't lose them
        int currentScene = SceneManager.GetActiveScene().buildIndex;        //grabs the current scene int

        SendStatsToEndScreen();                             
        WinScreenManager.correctAnswer += question.correctlyAnswered;       //add the correct answers to the running total
        WinScreenManager.incorrectAnswer += question.incorrectlyAnswered;   //add the incorrect answers to the running total
        SceneManager.LoadScene((currentScene + 1));                             // Load the next scene  
    }

    public static void SendStatsToEndScreen()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;        //grabs the current scene int

        WinScreenManager.numOfPlatforms[(currentScene - 1)] = QPopUpManager.landingCount; //keeps track of the amount of platforms you landed on (-1 to take main menu into account)
    }
}

