using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class IntroductionManager : MonoBehaviour {

    [Tooltip("The panels you want to display in the intro.")]
    public GameObject[] panels;
    [Tooltip("Delay before next panel can be seen.")]
    public int clickDelay = 2;          //the delay between being able to skip through them all
    int cnt;                            //a counter to keep track of the currrent panel
    bool isDelayed;                     //bool to handle the click delay
    // Use this for initialization
    void Start()
    {
        AdvanceScene();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)  // When any key is pressed and let go...
        {
            StartCoroutine(DelayClick());
        }
    }

    IEnumerator DelayClick()
    {
        if (!isDelayed)
        {
            isDelayed = true;                                                  //prevents delay from happening twice
            AdvanceScene();                                                     //display next panel
            yield return new WaitForSeconds(clickDelay);                       //prevents spam clicking
            isDelayed = false;
        }
    }

    void AdvanceScene()
    {
        foreach (GameObject panel in panels) //turn off all the panels
        {
            panel.SetActive(false);
        }

        panels[cnt].SetActive(true);    //turn on the one we want

        cnt++;                          //prepare for the next panel

        if (cnt >= panels.Length)       //if we'll activated all the panels
            SceneManager.LoadScene(1);  //load the first level of the game
    }
}

