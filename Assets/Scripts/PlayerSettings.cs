using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class PlayerSettings : MonoBehaviour
{

    public AudioMixer audioMixer;

    public void Awake()
    {
        if(!PlayerPrefs.HasKey("music"))
        {
            PlayerPrefs.SetFloat("music", 0);
            
            //Set

            PlayerPrefs.Save();
        }
        //2
        else
        {
            audioMixer.SetFloat("volume", PlayerPrefs.GetFloat("music"));
        }
    }
}
