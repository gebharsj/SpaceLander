using UnityEngine;
using System.Collections;

public class DeathManager : MonoBehaviour {

    public Transform startPosition;

    FuelConsumption fuel;

	// Use this for initialization
	void Start ()
    {
        fuel = GetComponent<FuelConsumption>();
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("DeathZone")) // change the tag to what you see fit
        {
            DeathActions();
        }
    }

    public void DeathActions() //performs all the actions needed to be performed on death
    {
        fuel.ResetFuel(); // reset fuel
        this.GetComponent<SpriteRenderer>().color = Color.white; //reset color
        this.GetComponent<Rigidbody2D>().velocity = Vector2.zero; //reset speed
        this.transform.position = startPosition.position; //reset position
        PointsManager.totalPoints = 0; // reset score
        LandingDetectionManager.hasFinished = false; //reset  ability to score
        //play death animation
    }
}

