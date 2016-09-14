using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpeedometerHandler : MonoBehaviour {

    public GameObject player;       //The player
    public Text speedText;
    Rigidbody2D shipRB;             //The RigidBody2D on the ship

	// Use this for initialization
	void Start () {
        shipRB = player.GetComponent<Rigidbody2D>();        //Cache reference to player's rigidbody
	}
	
	// Update is called once per frame
	void Update ()
    {
        
    }

    void FixedUpdate()
    {
        DisplaySpeed();
    }

    void DisplaySpeed()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, -Mathf.Abs(shipRB.velocity.magnitude * 15));
        speedText.text = Mathf.Abs(shipRB.velocity.magnitude * 6).ToString();
    }    
}