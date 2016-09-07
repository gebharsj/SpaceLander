using UnityEngine;
using System.Collections;

public class LandingDetectionManager : MonoBehaviour {

    public float maxLandingSpeed; //over what speed does a ship crash at
    [HideInInspector]
    public bool frontLanded; //the bool connected with the front
    [HideInInspector]
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
                Crashing();
                print(this.GetComponent<Rigidbody2D>().velocity.y);
                hasFinished = true;
            }
        }
	}

    void Crashing()
    {
        if (Mathf.Abs(this.GetComponent<Rigidbody2D>().velocity.y) > maxLandingSpeed)
        {
            Debug.LogError("WE'VE Crashed!");
            this.GetComponent<SpriteRenderer>().color = new Color32(255, 0, 0, 255);
        }
    }
}
