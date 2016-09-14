using UnityEngine;

public class ShipControls : MonoBehaviour
{
    [Tooltip("Speed left or right.")]
    public float horizontalSpeed;                                       //left and right speed
    [Tooltip("Power of the thrust")]
    public float thrustPower;                                           //force for thrust


    private FuelConsumption _fuelConsumption;                           // Fuel is updated through this script.
    private PopUp PopUpFinished;                                        // Check if the pop-up is finished

    private void Start()
    {
        _fuelConsumption = gameObject.GetComponent<FuelConsumption>();                                  // Initialize the FuelConsumption Script
        PopUpFinished = GameObject.Find("PopUp").GetComponent<PopUp>();                                 // Find the PopUp script

        if (_fuelConsumption == null)
            Debug.LogError("Fuel is not attached to the player.");

        if (PopUpFinished == null) {
            Debug.LogError("There is no Pop-up script found");
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        // When the question is answered and instructions are seen, then controls are available
        if (PopUpFinished.startLevel)
        {
            //--------------Gets the Left and Right Arrows and adds an amount of force based upon Horizontal Speed-----------
            float xInput = Input.GetAxis("Horizontal");

            if (xInput > 0)
            {
                this.GetComponent<Rigidbody2D>().AddForce(new Vector2(10f * horizontalSpeed, 0));
            }
            else if (xInput < 0)
            {
                this.GetComponent<Rigidbody2D>().AddForce(new Vector2(-10f * horizontalSpeed, 0));
            }

            //--------------Gets Speed and adds an amount of force based upon thrust power-----------
            if (Input.GetKey(KeyCode.Space))
            {
                if (FuelConsumption.fuelAmount > 0)  // Check if there is enough fuel for thrusters
                {
                    this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 10f * thrustPower));
                    _fuelConsumption.FuelTank();   // Fuel is deprecated while the space bar is down                
                }
                else
                {
                    Debug.Log("Fuel has run out!");
                    //Trigger crash
                }
            }
        }         
    }
}