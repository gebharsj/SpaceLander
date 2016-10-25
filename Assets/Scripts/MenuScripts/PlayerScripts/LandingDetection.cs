using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LandingDetection : MonoBehaviour {

    LandingDetectionManager manager; // the script that manages the other two
    bool platformFinished = false;   // If the platform is no longer available
    GameObject platform;            // get the platform

    // Use this for initialization
    void Start ()
    {
        manager = transform.parent.GetComponent<LandingDetectionManager>(); //should be on the main ship

        if (manager == null)
            Debug.LogError("The parent of Landing Detection doesn't have the manager. Did you place it in the wrong spot?");
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Landing"))                // Looks to see if it has hit the landing pad
        {
            if (this.tag.Equals("Front"))               // figures out if it is the front or the back
                manager.frontLanded = true;             //turns the bool on
            else
                manager.endLanded = true;

            manager.platformPoints = other.GetComponent<PlatformManager>().pointValue; //sets the point value in the manager
            platformFinished = true;                    // If the platform has been landed on
            platform = other.gameObject;                // Assign gameObject to a variable to bring to GUI method
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag.Equals("Landing"))                // Looks to see if it have left the landing pad
        {
            if (manager.endLanded && manager.frontLanded)
            {
                if (other.isTrigger)                    // Check if the collider is a trigger
                {
                    other.enabled = false;                              // if so, turn off the trigger
                    LandingDetectionManager.hasFinished = false;        // the level is not finished
                    QuestionDisplay.hasApplied = false;                 // allows the options to beScrambled again
                }
                else
                    print(other.name);
            }

            //if (this.tag.Equals("Front"))               // figures out if it is the front or the back
                manager.frontLanded = false;            //turns the bool off
            //else
                manager.endLanded = false;
        }
    }

    void OnGUI()
    {                                                      // Image can only be accessed through GUI
        if (platformFinished)
        {
            platform.GetComponent<Image>().color = Color.red;           // Change the platform to red
        }
    }
}
