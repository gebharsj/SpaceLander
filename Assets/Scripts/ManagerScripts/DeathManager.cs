using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour {

    static GameObject player;              //player, since there's only one

    private static bool isDelayed;         //checking if delay is happening

    [Tooltip("The delay before the level reloads")]
    public int animationDelay;             //delay before the level reloads

    private static int staticDelay;

    // Use this for initialization
    void Start ()
    {
        staticDelay = animationDelay;
        player = GameObject.FindGameObjectWithTag("Player");                                                       //find player

        if (player == null)
            Debug.LogError("There is no one tagged \"Player\".");
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
        int currentScene = SceneManager.GetActiveScene().buildIndex;  //grabs the current scene
        SceneManager.LoadScene(currentScene);                           //loads the current scene
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

