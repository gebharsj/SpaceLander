using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QuestionDisplay : MonoBehaviour {

    public Text questionText;

    TextImportation _textImportation;

	// Use this for initialization
	void Start () {
        _textImportation = GameObject.FindGameObjectWithTag("GameManager").GetComponent<TextImportation>();
        
        questionText.text = _textImportation.questionList[0].Question + "\n"
                            + _textImportation.questionList[0].OptionOne + "\n"
                            + _textImportation.questionList[0].OptionTwo + "\n"
                            + _textImportation.questionList[0].OptionThree + "\n"
                            + _textImportation.questionList[0].OptionFour + "\n"
                            + _textImportation.questionList[0].Answer;
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}

/* function that takes an int, uses the int for the _textImportation index, apply the info to the various ui elements
 * the int should be random * 
 */