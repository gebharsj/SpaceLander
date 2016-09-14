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
	void Start () {
	    try
        {
            using (StreamReader sr = new StreamReader("test.txt"))
            {
                string line;

                while((line = sr.ReadLine()) != null)
                {
                    string[] temp = line.Split(breakPoint);

                    if(temp.Length == 6)
                    {
                        Questions qt = new Questions();
                        qt.Question = temp[0];
                        qt.OptionOne = temp[1];
                        qt.OptionTwo = temp[2];
                        qt.OptionThree = temp[3];
                        qt.OptionFour = temp[4];
                        qt.Answer = temp[5];
                        questionList.Add(qt);

                        qt.DisplayQuestion();

                    }
                    else
                    {
                        Debug.LogError("Your text file has either too much, or too little information!");
                    }
                    

                    //for (int i = 0; i < temp.Length; i++)
                    //{
                    //    Debug.Log(temp[i]);                        
                    //}
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
