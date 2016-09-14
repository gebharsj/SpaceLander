using UnityEngine;

public class LandingDetectionManager : MonoBehaviour
{
    public float maxLandingSpeed; //over what speed does a ship crash at

    [HideInInspector]
    public bool frontLanded; //the bool connected with the front

    [HideInInspector]
    public bool endLanded; // the bool connected with the back

    [HideInInspector]
    public int platformPoints; //the points coming from the paltform you're landing

    public static bool hasFinished; //the activation of the win condition, prevents the effect of winning from happening multiple times

    // Update is called once per frame
    private void Update()
    {
        if (frontLanded || endLanded) //when either one points have hit the pad
            Crashing();

        if (frontLanded && endLanded) //when both points have landed
        {
            if (!hasFinished) //activate win condition once
            {
                Debug.Log("YOU'VE LANDED!");
                PointsManager.AddPoints(platformPoints); // add the points of the platform
                int fuelRemaining = (int) this.GetComponent<FuelConsumption>().fuelAmount;
                PointsManager.AddPoints(fuelRemaining); // add the remaining fuel
                hasFinished = true;
            }
        }
    }

    public void Crashing()
    {
        if (Mathf.Abs(this.GetComponent<Rigidbody2D>().velocity.y) > maxLandingSpeed) //if speed is greater...
        {
            hasFinished = true;
            Debug.LogError("WE'VE Crashed!");
            this.GetComponent<SpriteRenderer>().color = new Color32(255, 0, 0, 255);
        }
    }
}