using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class SettingsMenu : MonoBehaviour
{

    public Slider volumeSlider;
    public AudioMixer audioMixer;
    
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("music", volume);
    }

    public void UpdateSlider()
    {
        float storedVolume = PlayerPrefs.GetFloat("music");
        volumeSlider.value = storedVolume;        
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
