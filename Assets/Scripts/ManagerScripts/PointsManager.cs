using UnityEngine;
using UnityEngine.UI;

public class PointsManager : MonoBehaviour
{
    public static int totalPoints; // the total points

    public static int savedPoints = 0; // the amount of points you've gotten

    [Tooltip("Text for the points.")]
    public Text pointsText; //the text for the points

    private string pointsHeader; //saving whatever you write in the text beforehand

    private void Start()
    {
        pointsHeader = pointsText.text; //save the header
    }

    private void Update()
    {
        pointsText.text = pointsHeader + " " + totalPoints.ToString(); //print the points
    }

    public static void AddPoints(int pointNum)
    {
        totalPoints += pointNum; //add the points
    }
}