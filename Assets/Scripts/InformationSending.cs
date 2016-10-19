using System.Net;

using UnityEngine;
using System.Collections;


public class InformationSending : MonoBehaviour
{
    public int level;
    public float timeElapsed;
    public string playerName;

    private const string URL = "http://staging.my.kidscom.com/jsp_a01_mkc/jsp_a01_b04_mis/unity_game_api/";
    private string urlParameters = "earn_vp.jsp";

    void Start()
    {
        InformationSending myObject = new InformationSending();
        myObject.level = 1;
        myObject.timeElapsed = 47.5f;
        myObject.playerName = "Hector is a nerd.";

        string json = JsonUtility.ToJson(myObject);

        
        //H
        

        //HttpWebRequest request = 
    }
	
}
