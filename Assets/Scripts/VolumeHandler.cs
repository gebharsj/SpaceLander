using UnityEngine;
using System.Collections;

public class VolumeHandler : MonoBehaviour {

    public AudioSource uISource;
    public AudioSource musicSource;

    public string uiVolume;
    public string musicVolume;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        uISource.volume = PlayerPrefs.GetFloat(uiVolume);
        musicSource.volume = PlayerPrefs.GetFloat(musicVolume);
    }
}