using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AudioControl : MonoBehaviour {

    public Slider volumeSlider;
    public Text volumeText;

    // Use this for initialization
    void Start()
    {
        if(volumeSlider == null)
        {
            Debug.LogError("VolumeSlider has not been set!");
        }

        if(volumeText == null)
        {
            Debug.LogError("VolumeText has not been set!");
        }

        SetVolumeText();
        SetVolumeValue();
    }

    public void SetVolume(string prefName)
    {
        SetVolumeText();
        SetVolumeValue();
    }

    public void Mute(string prefName)
    {
        volumeSlider.value = 0;
        SetVolumeText();
        SetVolumeValue();
    }

    void SetVolumeValue()
    {
        VolumeHandler.volumeValue = volumeSlider.value;
    }

    void SetVolumeText()
    {
        volumeText.text = "<b><i><color=purple><size=" + ((volumeSlider.value + 1) * 100).ToString() + ">Volume!</size></color></i></b>";
    }
}