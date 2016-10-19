using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class QPopUpManager : MonoBehaviour {

    [Tooltip("All the Choices for the Answer")]
    public GameObject[] answers;                                // Array of all the answer buttons
    [Tooltip("The Buttons that you click on after the question")]
    public GameObject[] answeredButtons;                        // The buttons available after question is answered

    public static int landingCount = 0;                               // How many times does the ship land on an active landing pad.

    public static int currentIndex = 0;                         //the current index you're using for questions
    [Tooltip("The amount of starting facts in the beginning")]
    public int startingFacts = 4;                               //amt of starting facts

    [HideInInspector]
    public static int correctlyAnswered = 0;                    //keeps track of the amount correct
    [HideInInspector]
    public static int incorrectlyAnswered = 0;                  //keeps track of the amount incorrect

    public List<int> randIndexs = new List<int>();              //the list of arrays
    static List<int> staticIndexs = new List<int>();            //storing static arrays

    TextImportation txtImport;                                  
    private FuelConsumption fuel;

    void Start()
    {
        landingCount = 0; //reset landingCount
        correctlyAnswered = 0;
        incorrectlyAnswered = 0;
        //=================Grab the Components================
        txtImport = GetComponent<TextImportation>();

        if (txtImport == null)
            Debug.LogError("There is no TextImportation attached to the Game Manager, or " + this.gameObject + " != GameManager.");

        fuel = GameObject.FindGameObjectWithTag("Player").GetComponent<FuelConsumption>();

        if (fuel == null)
            Debug.LogError("Fuel is not attached to the player.");

        int length = txtImport.questionList.Count;  //gets the length of the questionList

        int cnt = startingFacts;                                //grabs the amount of indexs that you want for facts

        while (cnt > 0)                             //while you try and grab it
        {
            int randNum = Random.Range(0, length);  //grabs a random number

            if (!randIndexs.Contains(randNum))      //if that number hasn't already been used
            {
                randIndexs.Add(randNum);            
                cnt--;                              //and decrement
            }
        }

        if (!PopUp.secondTime) //static == instance
        {
            for (int index = 0; index < randIndexs.Count; index++)
            {
                staticIndexs.Add(randIndexs[index]);
            }
        }
        else //instance == static
        {
            randIndexs.Clear();
            for (int index = 0; index < staticIndexs.Count; index++)
            {
                randIndexs.Add(staticIndexs[index]);
            }
        }

    }

    public void SetIndex()
    {
        int randNum = randIndexs[Random.Range(0, randIndexs.Count)]; //gets the index out of the possible nums

        randIndexs.Remove(randNum);                                  //remove it, to prevent doubles

        currentIndex = randNum;                                     //sets it, allows other scripts to grab
    }

   public void CheckIfCorrect(string optionText)        //brings in the answer you clicked on
    {
        string rightAnswer = txtImport.questionList[currentIndex].Answer;
        if (optionText.Equals(rightAnswer))
        {
            FuelConsumption.fuelAmount += fuel.platformAddition;            // adds the amount of fuel dictated

            if (FuelConsumption.fuelAmount > fuel.fuelStartAmount)          //if you go over, goes back to the max
                FuelConsumption.fuelAmount = fuel.fuelStartAmount;

            fuel.fuelText.text = "Fuel: " + FuelConsumption.fuelAmount;     //simple text to show
            correctlyAnswered++;
        }
        else
            incorrectlyAnswered++;

        ChangeColor(rightAnswer);
    }

    void ChangeColor(string ansText)
    {
        for (int index = 0; index < answers.Length; index++)
        {
            if (answers[index].GetComponentInChildren<Text>().text.Equals(ansText))
                answers[index].GetComponent<Image>().color = Color.green;  //correct choice is green
            else
                answers[index].GetComponent<Image>().color = Color.red;    //incorrect choice is red 
        }
    }

    public void ResetColor()
    {
        for (int index = 0; index < answers.Length; index++)
        {
            answers[index].GetComponent<Image>().color = Color.white;       //resets all the buttons to white
        }
    }
  
    public void WasAnswered()
    {
        for (int i = 0; i < answers.Length; i++)                // For every answer button...   
        {
            answers[i].SetActive(false);                        // disable it ( Will eventually change color)
        }

        landingCount++;                                         // Increment to count the landing
        if (landingCount < 3)                                   // If all the platforms are not landed upon
        {
            for (int i = 0; i < answeredButtons.Length; i++)
            {      // For each option afterward...
                answeredButtons[i].SetActive(true);                 // enable both ContinuePlaying and NextLevel
            }
        }
        else {
            answeredButtons[1].SetActive(true);                     // if all the platform have been landed upon, only set NextLevel active.
        }

    }
}
