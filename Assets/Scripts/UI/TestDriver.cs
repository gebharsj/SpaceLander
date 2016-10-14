using UnityEngine;
using System.Collections;

public class TestDriver : MonoBehaviour {

    int cnt = 0;
	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
        cnt++;

        if (BasicUtilities<string>.onlyOnce("Hello"))
            print("Cheese");

        if (cnt > 100)
        {
            BasicUtilities<string>.resetOnce("Hello");
            cnt = 0;
            print("reset");
        }

	}
}
