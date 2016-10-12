using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class IntroductionManager : MonoBehaviour {

    [Tooltip("The panels you want to display in the intro.")]
    public GameObject[] panels;
    [Tooltip("Delay before next panel can be seen.")]
    public float clickDelay = 2;          //the delay between being able to skip through them all
    [HideInInspector]
    public int cnt = -1;                //a counter to keep track of the currrent panel
    bool isDelayed;                     //bool to handle the click delay
    // Use this for initialization
    void Start()
    {
        AdvanceScene(true);                                                     //setups on the panels correctly on start
    }

    public IEnumerator DelayClick(bool isAdvance)                               //based upon bool
    {
        if (!isDelayed)
        {
            isDelayed = true;                                                  //prevents delay from happening twice
            AdvanceScene(isAdvance);                                            //display next panel
            yield return new WaitForSeconds(clickDelay);                       //prevents spam clicking
            isDelayed = false;
        }
    }

    void AdvanceScene(bool isAdvance)
    {
        if (isAdvance)          //if true, go forward
            cnt++;
        else
            cnt--;              //if false, go back

        foreach (GameObject panel in panels) //turn off all the panels
        {
            panel.SetActive(false);
        }

        panels[cnt].SetActive(true);    //turn on the one we want        
    }
}

