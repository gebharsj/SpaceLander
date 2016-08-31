using UnityEngine;
using System.Collections;

public class LandingDetection : MonoBehaviour {

    LandingDetectionManager manager; // the script that manages the other two

	// Use this for initialization
	void Start ()
    {
        manager = transform.parent.GetComponent<LandingDetectionManager>(); //should be on the main ship

        if (manager == null)
            Debug.LogError("The parent of Landing Detection doesn't have the manager. Did you place it in the wrong spot?");
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Landing")) // Looks to see if it has hit the landing pad
        {
            if (this.name.Equals("FrontEnd"))// figures out if it is the front or the back
                manager.frontLanded = true; //turns the bool on
            else
                manager.endLanded = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag.Equals("Landing")) // Looks to see if it have left the landing pad
        {
            if (this.name.Equals("FrontEnd")) // figures out if it is the front or the back
                manager.frontLanded = false; //turns the bool off
            else
                manager.endLanded = false;
        }
    }
}
