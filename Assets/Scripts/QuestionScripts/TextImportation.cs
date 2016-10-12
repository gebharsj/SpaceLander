using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

public class TextImportation : MonoBehaviour {

    public List<Questions> questionList;
    public string textFileName;
    [TextArea(15, 30)]
    public string line;

    public char breakPoint;

	// Use this for initialization
	void Start ()
    {
        int cnt = 0;

        string[] temp = line.Split(breakPoint);

        //if (temp[temp.Length - 1] == null) break;

        while (cnt < (temp.Length - 1))
        {
            Questions qt = new Questions();
            qt.Fact = temp[0 + cnt];
            qt.Question = temp[1 + cnt];
            qt.OptionOne = temp[2 + cnt];
            qt.OptionTwo = temp[3 + cnt];
            qt.OptionThree = temp[4 + cnt];
            qt.OptionFour = temp[5 + cnt];
            qt.Answer = temp[6 + cnt];
            questionList.Add(qt);
            cnt += 7;
            print(cnt);
        }
    //}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
