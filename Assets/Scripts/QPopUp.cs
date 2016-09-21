using UnityEngine;
using System.Collections;

public class QPopUp : MonoBehaviour {

    public GameObject[] answers;                                // Array of all the answer buttons
    public GameObject[] answeredButtons;                        // The buttons available after question is answered

    private int landingCount = 0;                               // How many times does the ship land on an active landing pad.

    public void WasAnswered() {
        for (int i = 0; i < answers.Length; i++)                // For every answer button...   
        {
            answers[i].SetActive(false);                        // disable it ( Will eventually change color)
        }

        landingCount++;                                         // Increment to count the landing
        if (landingCount < 3)                                   // If all the platforms are not landed upon
        {
            for (int i = 0; i < answeredButtons.Length; i++)
            {      // For each option afterward...
                answeredButtons[i].SetActive(true);                 // enable both ContinuePlaying and NextLevel
            }
        }
        else {
            answeredButtons[1].SetActive(true);                     // if all the platform have been landed upon, only set NextLevel active.
        }

    }
}
