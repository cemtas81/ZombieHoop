using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.NiceVibrations;

public class Options : MonoBehaviour
{
    public GameObject menu;
  
    public GameObject soundOff;
    public GameObject vibOn;
  
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Sound")==1)
        {
            AudioListener.pause = true;
            soundOff.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Sound")==0)
        {
            AudioListener.pause = false;
            soundOff.SetActive(false);
        }
        if (PlayerPrefs.GetInt("Vib")==1)
        {
            MMVibrationManager.SetHapticsActive(false);
            vibOn.SetActive(false);
        }
        if (PlayerPrefs.GetInt("Vib")==0)
        {
            MMVibrationManager.SetHapticsActive(true);
            vibOn.SetActive(true);
        }

    }

    // Update is called once per frame
   public void Menu()
    {
        menu.SetActive(!menu.activeSelf);
    }
    public void Sound()
    {
        if (soundOff.activeInHierarchy==false)
        {
            soundOff.SetActive(true);
            PlayerPrefs.SetInt("Sound", 1);
            AudioListener.pause=true;
        }
        else if (soundOff.activeInHierarchy==true)
        {
            soundOff.SetActive(false);
            PlayerPrefs.SetInt("Sound", 0);
            AudioListener.pause = false;
        }
    }
    public void Vib()
    {
        if (vibOn.activeInHierarchy==true)
        {
            vibOn.SetActive(false);
            PlayerPrefs.SetInt("Vib", 1);
            MMVibrationManager.SetHapticsActive(false);
        }
        else if (vibOn.activeInHierarchy==false)
        {
            vibOn.SetActive(true);
            PlayerPrefs.SetInt("Vib", 0);
            MMVibrationManager.SetHapticsActive(true);
        }
    }
}
