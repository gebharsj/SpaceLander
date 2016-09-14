using UnityEngine;
using System.Collections;

public class DeathManager : MonoBehaviour {

    [Tooltip("Where the player starts at.")]
    public Transform startPosition;        //where the player should go

    static Vector3 realStart;              //convert the transform into a Vector3

    static GameObject player;              //player, since there's only one

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");                                                       //find player

        if (player == null)
            Debug.LogError("There is no one tagged \"Player\".");

        realStart = new Vector3(startPosition.position.x, startPosition.position.y, player.transform.position.z); //convert the transform to vector3
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("DeathZone")) // change the tag to what you see fit
        {
            DeathActions();               
        }
    }

    public static void DeathActions() //performs all the actions needed to be performed on death
    {
        FuelConsumption.ResetFuel();                                //reset fuel
        player.GetComponent<SpriteRenderer>().color = Color.white;  //reset color
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero; //reset speed
        player.transform.position = realStart;                      //reset position
        PointsManager.totalPoints = 0;                              //reset score
        LandingDetectionManager.hasFinished = false;                //reset  ability to score
        //play death animation
    }
}

