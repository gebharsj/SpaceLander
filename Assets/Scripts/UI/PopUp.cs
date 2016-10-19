using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;

public class PopUp : MonoBehaviour {

    public Text[] text;                                 // Initialize the text
    public static bool secondTime;                     // prevents popup from opening multiple times
    public GameObject pauseButton;

    void Start()
    {
        if (!secondTime)
        {
            //==================Grab All the Components==============
            text = GetComponentsInChildren<Text>();      // Get the text component within the children

            if (text == null)
                Debug.LogError("There is no Text component attached within the children");

            GameObject gameManager = GameObject.FindGameObjectWithTag("GameManager");

            if (gameManager == null)
                Debug.LogError("There is no gameobject tagged \"GameManager\".");

            TextImportation txtImport = gameManager.GetComponent<TextImportation>();
            if (txtImport == null)
                Debug.LogError("Text Importation is not attached to the Game Manager.");

            QPopUpManager qManager = gameManager.GetComponent<QPopUpManager>();
            if (qManager == null)
                Debug.LogError("There is QManager in gameManager.");

            Time.timeScale = 0;                                                         // No gravity or force or controls will be available.

            for (int index = 1; index < text.Length -1; index++)                           //grabs the facts
            {
                text[index].text = txtImport.questionList[qManager.randIndexs[(index - 1)]].Fact; 
            }
        }
        else
            gameObject.SetActive(false);            // Disable the gameObject
    }

    public void StartPlaying() {
        
        Time.timeScale = 1;                     // Gravity, force, and controls can be applied.
        pauseButton.SetActive(true);
        gameObject.SetActive(false);            // Disable the gameObject
        secondTime = true;
    }
}
