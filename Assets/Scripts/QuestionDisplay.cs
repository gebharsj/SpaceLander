using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QuestionDisplay : MonoBehaviour {

    public Text[] textArrays = new Text[5]; //the list of the texts that appear in the pop-up
    public static string answerText;        //establish what the answer is

    public int questionNumber = 0;          //the index of the question appearing

    TextImportation _textImportation;

    [HideInInspector]
    public bool hasApplied;                 //makes sure you only scramble onceS

    public void ApplyText()
    {
        _textImportation = GameObject.FindGameObjectWithTag("GameManager").GetComponent<TextImportation>();

        string result = scrambleResult();                                        //returns a 4 digit string

        textArrays[0].text = _textImportation.questionList[0].Question;          // Apply the text from the text document

        if (!hasApplied) //makes it only happen once
        {
            for (int index = 0; index < (textArrays.Length - 1); index++)
            {
                string choiceString = result.Substring(index, 1);
                int choice = int.Parse(choiceString);

                switch (choice) //sets the index
                {
                    case 1: //depending on the option
                        textArrays[(index + 1)].text = _textImportation.questionList[questionNumber].OptionOne; 
                        break;
                    case 2:
                        textArrays[(index + 1)].text = _textImportation.questionList[questionNumber].OptionTwo;
                        break;
                    case 3:
                        textArrays[(index + 1)].text = _textImportation.questionList[questionNumber].OptionThree;
                        break;
                    case 4:
                        textArrays[(index + 1)].text = _textImportation.questionList[questionNumber].OptionFour;
                        break;
                }
            }

            answerText = _textImportation.questionList[0].Answer;     // Establish which is the answer
            hasApplied = true;                                        
        }
    }

    //-----------------Returns a 4 digits scamble with digits 1-4-----------
    string scrambleResult() //
    {
        bool[] arrayB = new bool[4];                    //bools to make sure no digit is repeated
        string scramble = "";

        for (int index = 0; index <= 50; index++)       //index of 50 to make sure that it fully scrambles
        {
            int result = Random.Range(1, textArrays.Length); //chose a random number between 1 and the max (default 5)

            switch (result)
            {
                case 1:
                    if (!arrayB[0]) //if it has not been chosen yet...
                    {
                        scramble += "1";    //add the number to the result
                        arrayB[0] = true;   //now it is chosen
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