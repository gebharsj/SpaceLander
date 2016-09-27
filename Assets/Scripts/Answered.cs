using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Answered : MonoBehaviour {

    public float waitTime;                              //Time to wait before disabling answer buttons
    private QPopUp question;                            // Reference the Question pop up script
    private FuelConsumption fuel;

    bool isWaiting;                                     //bool to make sure the coroutine dosen't run the WaitForSeconds while it's already waiting

    void Start() {
        question = GameObject.Find("Canvas").GetComponent<QPopUp>();        // Find the script
        fuel = GameObject.FindGameObjectWithTag("Player").GetComponent<FuelConsumption>();
    }

    public void Answer() {
        if (gameObject.name == "Answer 1")                                  // Find the correct answer... will be a variable
        {
            print("This is the correct answer");                            // Test for now.. will turn green
            gameObject.GetComponent<Image>().color = Color.green;           // Turns the button Image green. To change the Text color we could do transform.GetComponentInChildren<Text>().color = Color.green;
            transform.GetComponentInChildren<Text>().color = Color.green;
            gameObject.GetComponent<Button>().interactable = false;
            FuelConsumption.fuelAmount += fuel.platformAddition;            // adds the amount of fuel dictated

            if (FuelConsumption.fuelAmount > fuel.fuelStartAmount)          //if you go over, goes back to the max
                FuelConsumption.fuelAmount = fuel.fuelStartAmount;

            fuel.fuelText.text = "Fuel: " + FuelConsumption.fuelAmount;     //simple text to show
        }
        else {
            print("This is the wrong answer");                              // All wrong answers will turn red
            gameObject.GetComponent<Image>().color = Color.red;           // Turns the button Image red. To change the Text color we could do transform.GetComponentInChildren<Text>().color = Color.red;
            transform.GetComponentInChildren<Text>().color = Color.red;
            gameObject.GetComponent<Button>().interactable = false;
        }

        StartCoroutine(Wait());

        
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

    public void NextLevel() {
        PopUp.secondTime = false;
        PointsManager.savedPoints = PointsManager.totalPoints;             //saves the points, can't lose them
        SceneManager.LoadScene(1);                                          // Load the next scene (loads game atm)
        
    }

    IEnumerator Wait()
    {
        if (!isWaiting)
        {
            isWaiting = true;
            yield return new WaitForSeconds(waitTime);
            question.WasAnswered();                                             // Enable the next buttons
            isWaiting = false;
        }
    }
}
