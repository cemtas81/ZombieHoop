using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExtraLevel : MonoBehaviour
{
   public void Bilardo()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(1))
        {
            SceneManager.LoadScene(2);
        }
        else
            SceneManager.LoadScene(0);
        PlayerPrefs.SetInt("level", 0);
        PlayerPrefs.Save();
    }
}
