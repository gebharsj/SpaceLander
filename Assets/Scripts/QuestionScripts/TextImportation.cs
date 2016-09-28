using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

public class TextImportation : MonoBehaviour {

    public List<Questions> questionList;
    public string textFileName;

    public char breakPoint;

	// Use this for initialization
	void Start ()
    {
        try
        {
            using (StreamReader sr = new StreamReader(textFileName))
            {
                string line;

                while((line = sr.ReadLine()) != null)
                {
                    string[] temp = line.Split(breakPoint);

                    if(temp.Length == 7)
                    {
                        Questions qt = new Questions();
                        qt.Fact = temp[0];
                        qt.Question = temp[1];
                        qt.OptionOne = temp[2];
                        qt.OptionTwo = temp[3];
                        qt.OptionThree = temp[4];
                        qt.OptionFour = temp[5];
                        qt.Answer = temp[6];
                        questionList.Add(qt);
                    }
                    else
                    {
                        Debug.LogError("Your text file has either too much, or too little information!");
                    }
                }
            }
        }
        catch(Exception e)
        {
            Debug.LogError("The file could not be read");
            Debug.LogError(e.Message);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
