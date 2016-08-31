using UnityEngine;
using System.Collections;

public class LandingDetectionManager : MonoBehaviour {

    public bool frontLanded; //the bool connected with the front
    public bool endLanded; // the bool connected with the back
    bool hasFinished; //the activation of the win condition, prevents the effect of winning from happening multiple times
	
	// Update is called once per frame
	void Update ()
    {
        if (frontLanded && endLanded) //when both points have landed
        {
            if (!hasFinished) //activate win condition once
            {
                Debug.Log("YOU'VE LANDED!");
                //other win conditions
                hasFinished = true;
            }
        }
	}
}
