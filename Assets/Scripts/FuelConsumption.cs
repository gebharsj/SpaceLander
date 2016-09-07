using UnityEngine;
using System.Collections;

public class FuelConsumption : MonoBehaviour {
    public float fuelAmount;                        // The amount of fuel at the beginning of the level.
    public float fuelCost = 0.2f;                   // Fuel cost while the thrusters are active
    public float fuelCostDivider = 2.0f;            // What the fuel cost is divided by, in order to avoid increasingly low decimals

    public float fuelTank() {                       // The current amount of fuel

        if (fuelAmount > 0) {
            fuelAmount -= fuelCost / fuelCostDivider;       // Fuel is deprecated by the Fuel Used / fuelCostDivider
        }
        else {
            fuelAmount = 0;
            // ---- Trigger end scene ------
        }
        return fuelAmount;                                  // Return the result
    }
}
