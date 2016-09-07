using UnityEngine;

public class GravityManager : MonoBehaviour
{
    public float gravityForce; //gets the gravity force you want

    // Use this for initialization
    private void Start()
    {
        UpdateGravity(gravityForce);
    }

    public void UpdateGravity(float newGravity) //allows you to adjust the gravity in a different script
    {
        Physics2D.gravity = new Vector2(0, -newGravity); //negative to make sure things go downwards
    }
}