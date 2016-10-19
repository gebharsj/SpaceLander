using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

public class TextImportation : MonoBehaviour {

    [Tooltip("The list of questions you have. Should appear as empty.")]
    public List<Questions> questionList;
    [TextArea(15, 30)]
    public string line;

    [Tooltip("Where the text splits into different forms")]
    public char breakPoint;

	// Use this for initialization
	void Start (){
        int cnt = 0;                        //in the index of where you are in the string

        string[] temp = line.Split(new char[] { breakPoint, '\n' }); //split the string into parts

        while (cnt < (temp.Length - 1))         //while you are not at the end
        {
            Questions qt = new Questions();     //declare new question
            qt.Fact = temp[0 + cnt];            //fill it
            qt.Question = temp[1 + cnt];
            qt.OptionOne = temp[2 + cnt];
            qt.OptionTwo = temp[3 + cnt];
            qt.OptionThree = temp[4 + cnt];
            qt.OptionFour = temp[5 + cnt];
            qt.Answer = temp[6 + cnt];
            questionList.Add(qt);
            cnt += 7;                           //increment cnt to keep up with the index
        }
    }
}
