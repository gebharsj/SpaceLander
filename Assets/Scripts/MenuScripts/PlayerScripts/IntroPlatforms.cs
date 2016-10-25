using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IntroPlatforms : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        gameObject.GetComponent<Image>().color = Color.red;
    }
}
