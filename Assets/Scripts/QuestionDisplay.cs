using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QuestionDisplay : MonoBehaviour {

    public Text questionText;               // Get the text for the question 
    public Text answerOne;                  //...and all the answers
    public Text answerTwo;
    public Text answerThree;
    public Text answerFour;
    public static string answerText;

    TextImportation _textImportation;

    string choice1;
    string choice2;
    string choice3;
    string choice4;

    public void ApplyText()
    {
        _textImportation = GameObject.FindGameObjectWithTag("GameManager").GetComponent<TextImportation>();

        string result = scrambleResult();
        print(result);

        questionText.text = _textImportation.questionList[0].Question;          // Apply the text from the text document
        answerOne.text = _textImportation.questionList[0].OptionOne;
        answerTwo.text = _textImportation.questionList[0].OptionTwo;
        answerThree.text = _textImportation.questionList[0].OptionThree;
        answerFour.text = _textImportation.questionList[0].OptionFour;
        answerText = _textImportation.questionList[0].Answer;                   // Establish which is the answer
    }

    string scrambleResult()
    {
        bool[] arrayB = new bool[4];
        string scramble = "";

        for (int index = 0; index <= 50; index++)
        {
            int result = Random.Range(1, 5);

            switch (result)
            {
                case 1:
                    if (!arrayB[0])
                    {
                        scramble += "1";
                        arrayB[0] = true;
                    }
                    break;
                case 2:
                    if (!arrayB[1])
                    {
                        scramble += "2";
                        arrayB[1] = true;
                    }
                    break;
                case 3:
                    if (!arrayB[2])
                    {
                        scramble += "3";
                        arrayB[2] = true;
                    }
                    break;
                case 4:
                    if (!arrayB[3])
                    {
                        scramble += "4";
                        arrayB[3] = true;
                    }
                    break;
                default:
                    break;
            }
        }

        return scramble;
        
    }
}

/* function that takes an int, uses the int for the _textImportation index, apply the info to the various ui elements
 * the int should be random * 
 */