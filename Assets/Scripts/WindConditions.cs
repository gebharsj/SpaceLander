using UnityEngine;

public class WindConditions : MonoBehaviour
{
    public float windSpeed; //the wind speed. Make it negative for left. Positive for right
    public GameObject wind; // the temporary wind that animates;
    private GameObject player; //the player
                               // Use this for initialization

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (player == null)
            Debug.LogError("No one is tagged \"Player\". Make sure the player is tagged correctly");

        //------------=========Animation for wind========-------------------------------
        //if (windSpeed > 0)
        //    wind.GetComponent<Animator>().SetBool("rightWind", true);
        //else if (windSpeed < 0)
        //    wind.GetComponent<Animator>().SetBool("rightWind", false);
        //else
        //    wind.GetComponent<Animator>().SetBool("isWind", false);
    }

    // Update is called once per frame
    private void Update()
    {
        player.GetComponent<Rigidbody2D>().AddForce(new Vector2(1f * windSpeed, 0)); // adding force to the player
    }
}