using UnityEngine;
using System.Collections;

public class VolumeHandler : MonoBehaviour {

    public AudioSource uISource;
    public AudioSource musicSource;

    public string volume;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        uISource.volume = PlayerPrefs.GetFloat(volume);
        musicSource.volume = PlayerPrefs.GetFloat(volume);
    }
}