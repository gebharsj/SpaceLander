using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;

public class PopUp : MonoBehaviour {

    public Text[] text;                                 // Initialize the text
    public static bool secondTime;                     // prevents popup from opening multiple times

    void Start()
    {
        if (!secondTime)
        {
            WinScreenManager.PrintValues();
            //=================Set that You've Arrived=================
            int currentScene = SceneManager.GetActiveScene().buildIndex;        //grabs the current scene int

            WinScreenManager.visitedArray[currentScene] = true;               //states that you have visited the planet you're going to
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

            for (int index = 1; index < text.Length; index++)                           //grabs the facts
            {
                text[index].text = txtImport.questionList[qManager.randIndexs[(index - 1)]].Fact; 
            }
        }
        else
            gameObject.SetActive(false);            // Disable the gameObject
    }

    void Update() {
        if (Input.anyKeyDown) {                     // When any key is pressed and let go...
            Time.timeScale = 1;                     // Gravity, force, and controls can be applied.
            gameObject.SetActive(false);            // Disable the gameObject
            secondTime = true;
        }
    }
}
