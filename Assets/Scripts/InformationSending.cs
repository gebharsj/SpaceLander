using UnityEngine;
using System.Collections;
using UnityEngine.Networking;


public class InformationSending : MonoBehaviour
{
    public string game_name;
    public int kids_id;
    public int num_points;
    public int num_kash;

    private const string URLVP = "http://staging.my.kidscom.com/jsp_a01_mkc/jsp_a01_b04_mis/unity_game_api/earn";

    public string curr = "_vp.jsp";
    public string kash = "_kash.jsp";

    void Start()
    {
        //StartCoroutine(SendInfoCurrency());
        StartCoroutine(SendInfoKidsKash());
    }

    IEnumerator SendInfoCurrency()
    { 
        InformationSending myObject = new InformationSending();
        myObject.game_name = "Rocket Lander";
        myObject.kids_id = 3951625;
        myObject.num_points = 500;

        string json = JsonUtility.ToJson(myObject);

        Debug.Log(json);

        UnityWebRequest www = UnityWebRequest.Get(URLVP + curr + "?game_name=" + myObject.game_name + "&kids_id=" + myObject.kids_id + "&num_points=" + myObject.num_points);

        print(www.url);
        //yield return null;
        yield return www.Send();

        if (www.isError)
        {
            Debug.Log(www.error + " : this has failed");
        }
        else
        {
            Debug.Log(www.downloadHandler.text);
            Debug.Log("request success");
        }
    }

    IEnumerator SendInfoKidsKash()
    {
        InformationSending myOtherObject = new InformationSending();
        myOtherObject.game_name = "Rocket Lander";
        myOtherObject.kids_id = 3951625;
        myOtherObject.num_kash = 50;

        string json = JsonUtility.ToJson(myOtherObject);

        Debug.Log(json);

        UnityWebRequest www = UnityWebRequest.Get(URLVP + kash+ "?game_name=" + myOtherObject.game_name + "&kids_id=" + myOtherObject.kids_id + "&num_kash=" + myOtherObject.num_kash);

        print(www.url);
        //yield return null;
        yield return www.Send();

        if (www.isError)
        {
            Debug.Log(www.error + " : this has failed");
        }
        else
        {
            Debug.Log(www.downloadHandler.text);
            Debug.Log("request success");
        }
    }

}
