using UnityEngine;

public class FuelConsumption : MonoBehaviour
{
    public float fuelStartAmount;                   // The amount of fuel at the beginning of the level.
    public float fuelAmount;                        // The amount you currently have
    public float fuelCost = 0.2f;                   // Fuel cost while the thrusters are active
    public float fuelCostDivider = 2.0f;            // What the fuel cost is divided by, in order to avoid increasingly low decimals

    DeathManager death;                             //brings in the deathManager to activate death

    void Start()
    {
        ResetFuel(); //saves the value at the start for future use
    }

    public float FuelTank()
    {                       // The current amount of fuel
        if (fuelAmount > 0)
        {
            fuelAmount -= fuelCost / fuelCostDivider;       // Fuel is deprecated by the Fuel Used / fuelCostDivider
        }
        else
        {
            fuelAmount = 0;
            //death.DeathActions();                         //not sure if that needs to be called here yet
            // ---- Trigger end scene ------
        }
        return fuelAmount;                                  // Return the result
    }

    public void ResetFuel()
    {
        fuelAmount = fuelStartAmount;  //resets the fuel
    }
}