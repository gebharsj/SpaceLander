using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PopUp : MonoBehaviour {

    public bool startLevel = false;                 // Is it okay to start the level?
    
    private Image[] images;                         // The images involved in the pop up
    private Text text;                              // Initialize the text

    void Start() {
        text = GetComponentInChildren<Text>();      // Get the text component within the children
        if (text == null) {
            Debug.LogError("There is no Text component attached within the children");
        }
    }

    void Update() {
        if (Input.anyKeyDown) {                     // When any key is pressed and let go...
            text.enabled = false;                   // ...turn off the text...

            images = GetComponentsInChildren<Image>();      // ... find all of the images within the pop-up...
            if (images == null) {
                Debug.LogError("There are no images attached within the children");
            }
            foreach (Image image in images) {
                image.enabled = false;                      // ... turn each off ...
            }
            startLevel = true;                              // ... The level begins.
        }
    }
}
