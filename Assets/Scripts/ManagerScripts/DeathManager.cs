using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour {

    [Tooltip("Where the player starts at.")]
    public Transform startPosition;        //where the player should go

    static GameObject player;              //player, since there's only one

    private static bool isDelayed;         //checking if delay is happening

    public int animationDelay;             //

    private static int staticDelay;

    // Use this for initialization
    void Start ()
    {
        staticDelay = animationDelay;
        player = GameObject.FindGameObjectWithTag("Player");                                                       //find player

        if (player == null)
            Debug.LogError("There is no one tagged \"Player\".");

        startPosition = GameObject.Find("StartPoint").GetComponent<Transform>();
        if (startPosition == null)
            Debug.LogError("Cannot find the startPosition");
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
        player.GetComponent<DeathManager>().StartCoroutine(DeathDelay());
        SceneManager.LoadScene(1);
    }

    static IEnumerator DeathDelay()
    {
        if (!isDelayed)
        {
            isDelayed = true;                                                   //prevents delay from happening twice
            player.GetComponent<ShipControls>().enabled = false;                //prevents player from moving when crashed
            yield return new WaitForSeconds(staticDelay);                       //delay for animation

            PointsManager.totalPoints = PointsManager.savedPoints;              //resets the points to the last level

            player.GetComponent<ShipControls>().enabled = true;                 //reset controls
            isDelayed = false;                                                  //allows delay to happen again
        }
    }
}

