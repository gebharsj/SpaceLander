using UnityEngine;
using System.Collections;

public class LandingDetectionManager : MonoBehaviour
{
    [Tooltip("What speed does a ship crash at.")]
    public float maxLandingSpeed;   //over what speed does a ship crash at
    [Tooltip("Delay for the ship to reset after crashing.")]
    public float animationDelay;    //delay for animation to play

    //[HideInInspector]
    public bool frontLanded;        //the bool connected with the front

    //[HideInInspector]
    public bool endLanded;          // the bool connected with the back

    public GameObject question;     // Needs to be public because inactive gameObjects cannot be "found"

    [HideInInspector]
    public int platformPoints;      //the points coming from the platform you're landing

    public static bool hasFinished; //the activation of the win condition, prevents the effect of winning from happening multiple times

    private bool isDelayed;         //checking if delay is happening

    private void Start()
    {
        hasFinished = false;
    }
    
    // Update is called once per frame
    private void Update()
    {
        if (frontLanded || endLanded) //when either one points have hit the pad
            Crashing();

        if (frontLanded && endLanded) //when both points have landed
        {
            if (!hasFinished)                                                                //activate win condition once
            {
                PointsManager.AddPoints(platformPoints);                                    // add the points of the platform
                int fuelRemaining = (int) FuelConsumption.fuelAmount;                       // get points for fuel
                PointsManager.AddPoints(fuelRemaining);                                     // add the remaining fuel
                Time.timeScale = 0;                                                         // Stop time while question is being answered
                question.SetActive(true);                                                   // Allow pop up to show
                question.GetComponent<QuestionDisplay>().ApplyText();                       // Use the questions and answers from the txt file.
                QPopUpManager.landingCount++;                                               // Keeps track of how many platforms you've landed on
                hasFinished = true;                                                         
            }
        }
    }

    public void Crashing()
    {
        if (Mathf.Abs(this.GetComponent<Rigidbody2D>().velocity.y) > maxLandingSpeed)   //if speed is greater...
        {
            Debug.LogError("WE'VE Crashed!");
            hasFinished = true;                                                 //prevents score from being added
            frontLanded = false;                                                //resets the landed bools
            endLanded = false;                                                  //resets the landed bools

            DeathManager.DeathActions();                                        //DEATH OCCURS
        }
    }
}