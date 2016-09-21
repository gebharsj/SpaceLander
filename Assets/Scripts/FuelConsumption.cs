using UnityEngine;
using UnityEngine.UI;

public class FuelConsumption : MonoBehaviour
{
    [Tooltip("Starting fuel amount.")]
    public float fuelStartAmount;                   // The amount of fuel at the beginning of the level.
    static float savedStartAmount;                  // Saved amount of fuel, used for static methods
    public static float fuelAmount;                 // The amount you currently have
    [Tooltip("Fuel cost while the thrusters are active.")]
    public float fuelCost = 0.2f;                   // Fuel cost while the thrusters are active
    [Tooltip("What the fuel cost is divided by, in order to avoid increasingly low decimals.")]
    public float fuelCostDivider = 2.0f;            // What the fuel cost is divided by, in order to avoid increasingly low decimals
    [Tooltip("The amount of fuel that platforms adds")]
    public float platformAddition = 20f;            //The amount of fuel that platforms adds

    public Text fuelText;                           //The text for the fuel
    public Image fuelImage;                         //The image for the fuel
    void Start()
    {
        savedStartAmount = fuelStartAmount;         //saving fuel to a static var

        if (fuelStartAmount == 0)
            Debug.LogError("Why is the starting amount of fuel 0?");

        ResetFuel(); //saves the value at the start for future use
    }

    public float FuelTank()
    {                       // The current amount of fuel
        fuelText.text = "Fuel: " + fuelAmount.ToString();

        fuelImage.fillAmount = fuelAmount;

        if (fuelAmount > 0)
        {
            fuelAmount -= fuelCost / fuelCostDivider;       // Fuel is deprecated by the Fuel Used / fuelCostDivider
        }
        else
        {
            fuelAmount = 0;
            //DeathManager.DeathActions();                  //not sure if that needs to be called here yet
            // ---- Trigger end scene ------
        }
        return fuelAmount;                                  // Return the result
    }

    public static void ResetFuel()
    {
        fuelAmount = savedStartAmount;  //resets the fuel
    }
}