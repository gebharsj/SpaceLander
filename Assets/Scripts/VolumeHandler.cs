using UnityEngine;
using System.Collections;

public class VolumeHandler : MonoBehaviour {

    public AudioSource uISource;
    public AudioSource musicSource;

    public static float volumeValue;

    // Use this for initialization
    void Start()
    {
        if(uISource == null)
        {
            Debug.LogError("UI Source has not been set!");
        }

        if(musicSource == null)
        {
            Debug.LogError("Music Source has not been set!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        uISource.volume = volumeValue;
        musicSource.volume = volumeValue;
    }
}