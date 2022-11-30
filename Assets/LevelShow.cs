using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LevelShow : MonoBehaviour
{
   
    void Start()
    {
        if (PlayerPrefs.GetInt("level") == 0)
        {
            PlayerPrefs.SetInt("level",1);
            PlayerPrefs.Save();
            //GetComponent<TMP_Text>().text = "Level" + 1;
        }
        else
            GetComponent<TMP_Text>().text ="Level"+ PlayerPrefs.GetInt("level").ToString();
    }

    
}
