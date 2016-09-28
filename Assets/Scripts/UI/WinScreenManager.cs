using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WinScreenManager : MonoBehaviour {

    public static int correctAnswer;
    public static int incorrectAnswer;

    public static bool[] visitedArray = new bool[9];

    public static int[] numOfPlatforms = new int[9];

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

        /*
        for (int index = 0; index < visitedArray.Length; index++)
        {
            printText.text += "\n " + visitedArray[index].ToString();
        }
        */

        for (int index = 0; index < numOfPlatforms.Length; index++)
        {
            printText.text += "\n " + numOfPlatforms[index].ToString();
        }
    }
}
