using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AudioControl : MonoBehaviour {

    public Slider volumeSlider;
    public Text volumeText;

    // Use this for initialization
    void Start()
    {
        SetVolumeText();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetVolume(string prefName)
    {
        SetVolumeText();
        PlayerPrefs.SetFloat(prefName, volumeSlider.value);
    }

    public void Mute(string prefName)
    {
        volumeSlider.value = 0;
        SetVolumeText();
        PlayerPrefs.SetFloat(prefName, volumeSlider.value);
    }

    void SetVolumeText()
    {
        volumeText.text = "<b><i><color=purple><size=" + ((volumeSlider.value + 1) * 100).ToString() + ">Volume!</size></color></i></b>";
    }
}