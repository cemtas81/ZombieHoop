using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StartGame : MonoBehaviour
{
    public GameObject nick;
    public GameObject vs;
    public TMP_InputField nam;
    public void Game()
    {
        PlayerPrefs.SetString("nicko", nam.text);
        PlayerPrefs.Save();
        StartCoroutine(basla());
    }
    public IEnumerator basla()
    {
        yield return new WaitForSeconds(1);
        if (vs.activeInHierarchy == true)
        {
            SceneManager.LoadScene(1);
        }
        else
           
            nick.SetActive(!nick.activeSelf);
            vs.SetActive(!vs.activeSelf);
    }
}
