using UnityEngine;
using System.Collections;

public class QPopUp : MonoBehaviour {

    public GameObject[] answers;                                // Array of all the answer buttons
    public GameObject[] answeredButtons;                        // The buttons available after question is answered

    public void WasAnswered() {
        for (int i = 0; i < answers.Length; i++)                // For every answer button...   
        {
            answers[i].SetActive(false);                        // disable it ( Will eventually change color)
        }
        for (int i = 0; i < answeredButtons.Length; i++) {      // For each option afterward...
            answeredButtons[i].SetActive(true);                 // enable them
        }
    }
}
