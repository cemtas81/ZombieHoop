using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class DeatachBody : MonoBehaviour
{

    public GameObject add;
    public int enemyskor;
    private HingeJoint2D[] parts;
    public TextMeshProUGUI enemyskortext;
    private NewAd adds;
    public AudioSource sfx;
    public AudioClip win;
    private void Start()
    {
        parts = GetComponentsInChildren<HingeJoint2D>();
        adds =add.GetComponent<NewAd>();

    }
    private void Update()
    {
        enemyskor = int.Parse(enemyskortext.text);
      
        
        if (enemyskor>=10)
        {

            WinCon();
            enemyskortext.text = "0";
        }
       
    }
 
    public void WinCon()
    {
        foreach (var hingeJoint2D in parts)
        {
            hingeJoint2D.enabled = false;
        }
        StartCoroutine(levelchange());
        sfx.PlayOneShot(win);
    }
    IEnumerator levelchange()
    {
      
        yield return new WaitForSeconds(2);
        adds.ShowInterstitial();
        //PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);
        //Time.timeScale = 0;
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(0);
    }
}
