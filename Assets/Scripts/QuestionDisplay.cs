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

        int r = Random.Range(0, 2);
        print(r);
        questionText.text = _textImportation.questionList[r].Question;          // Apply the text from the text document
        answerOne.text = _textImportation.questionList[r].OptionOne;
        answerTwo.text = _textImportation.questionList[r].OptionTwo;
        answerThree.text = _textImportation.questionList[r].OptionThree;
        answerFour.text = _textImportation.questionList[r].OptionFour;
        answerText = _textImportation.questionList[r].Answer;                   // Establish which is the answer
    }
}

/* function that takes an int, uses the int for the _textImportation index, apply the info to the various ui elements
 * the int should be random * 
 */