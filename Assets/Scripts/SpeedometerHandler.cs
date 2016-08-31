using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpeedometerHandler : MonoBehaviour {

    public GameObject player;       //The player
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
        transform.Rotate(0f, 0f, -Mathf.Abs(shipRB.velocity.y));
        ClampRotation("z", 90, -90, 0);
    }

    void ClampRotation(string clampAngle, float minAngle, float maxAngle, float clampAroundAngle = 0)
    {
        //clampAngle is the angle that you want to clamp. For example, pass "x" into the function to clamp the x angle
        //clampAroundAngle is the angle you want the clamp to originate from
        //For example a value of 90, with a min=-45 and max=45, will let the angle go 45 degrees away from 90

        //Adjust to make 0 be right side up
        clampAroundAngle += 180;

        float rotationAngle;

        switch (clampAngle)
        {
            case "x":
            case "X":
                //Get the angle of the rotationAngle axis and rotate it up side down
                rotationAngle = transform.rotation.eulerAngles.x - clampAroundAngle;

                rotationAngle = WrapAngle(rotationAngle);

                //Move range to [-180, 180]
                rotationAngle -= 180;

                //Clamp to desired range
                rotationAngle = Mathf.Clamp(rotationAngle, minAngle, maxAngle);

                //Move range back to [0, 360]
                rotationAngle += 180;

                //Set the angle back to the transform and rotate it back to right side up
                transform.rotation = Quaternion.Euler(rotationAngle + clampAroundAngle, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

                break;

            case "y":
            case "Y":
                //Get the angle of the rotationAngle axis and rotate it up side down
                rotationAngle = transform.rotation.eulerAngles.y - clampAroundAngle;

                rotationAngle = WrapAngle(rotationAngle);

                //Move range to [-180, 180]
                rotationAngle -= 180;

                //Clamp to desired range
                rotationAngle = Mathf.Clamp(rotationAngle, minAngle, maxAngle);

                //Move range back to [0, 360]
                rotationAngle += 180;

                //Set the angle back to the transform and rotate it back to right side up
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, rotationAngle + clampAroundAngle, transform.rotation.eulerAngles.z);

                break;

            case "z":
            case "Z":
                //Get the angle of the rotationAngle axis and rotate it up side down
                rotationAngle = transform.rotation.eulerAngles.z - clampAroundAngle;

                rotationAngle = WrapAngle(rotationAngle);

                //Move range to [-180, 180]
                rotationAngle -= 180;

                //Clamp to desired range
                rotationAngle = Mathf.Clamp(rotationAngle, minAngle, maxAngle);

                //Move range back to [0, 360]
                rotationAngle += 180;

                //Set the angle back to the transform and rotate it back to right side up
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, rotationAngle + clampAroundAngle);

                break;

            default:
                return;
        }
        
    }

    //Make sure angle is within 0,360 range
    float WrapAngle(float angle)
    {
        //If its negative rotate until its positive
        while (angle < 0)
            angle += 360;

        //If its to positive rotate until within range
        return Mathf.Repeat(angle, 360);
    }
}
