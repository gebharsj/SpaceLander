using UnityEngine;
using System.Collections;

public class Questions : MonoBehaviour{

    string fact;
    string question;
    string optionOne;
    string optionTwo;
    string optionThree;
    string optionFour;
    string answer;

    public string Fact
    {
        get { return fact; }
        set { fact = value; }
    }

    public string Question
    {
        get { return question; }
        set { question = value; }
    }

    public string OptionOne
    {
        get { return optionOne; }
        set { optionOne = value; }
    }

    public string OptionTwo
    {
        get { return optionTwo; }
        set { optionTwo = value; }
    }

    public string OptionThree
    {
        get { return optionThree; }
        set { optionThree = value; }
    }

    public string OptionFour
    {
        get { return optionFour; }
        set { optionFour = value; }
    }

    public string Answer
    {
        get { return answer; }
        set { answer = value; }
    }


    /*public void DisplayQuestion()
    {
        Debug.Log(fact);
        Debug.Log(question);
        Debug.Log(optionOne);
        Debug.Log(optionTwo);
        Debug.Log(optionThree);
        Debug.Log(optionFour);
        Debug.Log(answer);
    }*/
}
