using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WinScreenManager : MonoBehaviour {

    public static int correctAnswer;
    public static int incorrectAnswer;

    public static bool[] visitedArray = new bool[9];

    public static int[] numOfPlatforms = new int[9];

    public Image[] levelPics = new Image[9];

    public string[] levelNames = new string[] { "Moon", "Mercury", "Venus", "Mars", "Jupiter", "Saturn", "Uranus", "Neptune", "Pluto" };

    public Sprite[] platformPics = new Sprite[4];

    public Text printText;

    void Start()
    {
        TextValue();
    }

    public static void PrintValues()
    {
        print(correctAnswer + ": correct answers.");
        print(incorrectAnswer + ": incorrect answers.");
    }

    public void TextValue()
    {
        printText.text = "Correct Answers: " + correctAnswer + "\n Incorrect Answers: " + incorrectAnswer;

        for (int index = 0; index < visitedArray.Length; index++)
        {
            if (!visitedArray[index])
                levelPics[index].GetComponent<Image>().color = Color.gray;

            levelPics[index].GetComponentInChildren<Text>().text = levelNames[index];

            levelPics[index].transform.GetChild(1).GetComponent<Image>().sprite = platformPics[numOfPlatforms[index]];            
        }
    }
}
