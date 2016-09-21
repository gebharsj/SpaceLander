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

    public void ApplyText() {
        _textImportation = GameObject.FindGameObjectWithTag("GameManager").GetComponent<TextImportation>();     

        questionText.text = _textImportation.questionList[0].Question;          // Apply the text from the text document
        answerOne.text = _textImportation.questionList[0].OptionOne;
        answerTwo.text = _textImportation.questionList[0].OptionTwo;
        answerThree.text = _textImportation.questionList[0].OptionThree;
        answerFour.text = _textImportation.questionList[0].OptionFour;
        answerText = _textImportation.questionList[0].Answer;                   // Establish which is the answer
    }
}

/* function that takes an int, uses the int for the _textImportation index, apply the info to the various ui elements
 * the int should be random * 
 */