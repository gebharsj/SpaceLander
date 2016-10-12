using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IntroButtons : MonoBehaviour {

    [Tooltip("Does this button advance the menus or not?")]
    public bool isAdvancing;            

    IntroductionManager intro;

    void Start()
    {
        intro = GameObject.FindGameObjectWithTag("Canvas").GetComponent<IntroductionManager>();

        if (intro == null)
            Debug.LogError("Canvas isn't tagged correctly as \"Canvas\" ");
    }


	// Update is called once per frame
	void Update ()
    {
        if (isAdvancing)
        {
            if (intro.cnt >= (intro.panels.Length - 1))             //if it is the last panel
                this.GetComponent<Button>().interactable = false;   //prevent going forward
            else
                this.GetComponent<Button>().interactable = true;
        }
        else
        {
            if (intro.cnt <= 0)                                     //if it is the first panel
                this.GetComponent<Button>().interactable = false;   //prevent going backwards
            else
                this.GetComponent<Button>().interactable = true;
        }
    }

    public void ChangeMenus()  
    {
        StartCoroutine(intro.DelayClick(isAdvancing));              //go foward or back based upon the bool
    }
}
