using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpeedometerHandler : MonoBehaviour {
    
    GameObject player;              //The player
    public Text speedText;
    Rigidbody2D shipRB;             //The RigidBody2D on the ship
    GameObject needle;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if(player == null)
        {
            Debug.LogError("Player has not been set!");
        }
        else
        {
            shipRB = player.GetComponent<Rigidbody2D>();        //Cache reference to player's rigidbody
        }  
        
        if(speedText == null)
        {
            Debug.LogError("SpeedText has not been set!");
        }

        needle = transform.GetComponentInChildren<Image>().gameObject;
        if (needle == null)
        {
            Debug.LogError("There is no needle set inside the holder.");
        }
        else
        {
            needle.transform.rotation = Quaternion.Euler(0, 0, 134); //makes it line up with the picture. Can change this if it doesn't line up correctly
        }
	}

    void FixedUpdate()
    {
        DisplaySpeed();
    }

    void DisplaySpeed()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, -Mathf.Abs(shipRB.velocity.magnitude));
        speedText.text = Mathf.Abs(shipRB.velocity.magnitude).ToString();
    }    
}