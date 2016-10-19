using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WinScreenManager : MonoBehaviour {

    public static int correctAnswer; //runnning total of correct answers
    public static int incorrectAnswer; //running total of incorrect answer

    public static bool[] visitedArray = new bool[9]; //checks if you have visited a planet or not

    public static int[] numOfPlatforms = new int[9]; //contains the amount of platforms per level

    public Image[] levelPics = new Image[9]; //the images on screen

    public string[] levelNames = new string[] { "Moon", "Mercury", "Venus", "Mars", "Jupiter", "Saturn", "Uranus", "Neptune", "Pluto" }; //the level names for printing

    public Sprite[] platformPics = new Sprite[4]; //the different images for the different outcomes

    public Text printText; //the text that the correct + incorrect print to

    void Start()
    {
        TextValue();
    }

    public void TextValue()
    {
        printText.text = "Correct Answers: " + correctAnswer + "\n Incorrect Answers: " + incorrectAnswer; //prints correct + incorrect

        for (int index = 0; index < visitedArray.Length; index++)
        {
            if (!visitedArray[index])
                levelPics[index].GetComponent<Image>().color = Color.gray; //if you haven't visited a planet, gray it out

            levelPics[index].GetComponentInChildren<Text>().text = levelNames[index]; //displays the level's name

            levelPics[index].transform.GetChild(1).GetComponent<Image>().sprite = platformPics[numOfPlatforms[index]]; //changes the platform pic to match the amount of platforms       
        }
    }
}
