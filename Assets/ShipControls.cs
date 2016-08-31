using UnityEngine;
using System.Collections;

public class ShipControls : MonoBehaviour {

    public float horizontalSpeed; //left and right speed
    public float thrustPower; //force for thrust
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        //--------------Gets the Left and Right Arrows and adds an amount of force based upon Horizontal Speed-----------
        float xInput = Input.GetAxis("Horizontal");

        if (xInput > 0)
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(10f * horizontalSpeed, 0));
        else if (xInput < 0)
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(-10f * horizontalSpeed, 0));


        //--------------Gets Speed and adds an amount of force based upon thrust power-----------
        if (Input.GetKey(KeyCode.Space))
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 10f * thrustPower));

    }
}
