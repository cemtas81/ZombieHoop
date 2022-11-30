using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class Begin : MonoBehaviour
{
    public TextMeshProUGUI Text;
    public GameObject player;
    public GameObject player2;
    public GameObject player3;
   
    public List<GameObject> enemies;
 
    void Start()
    {
        
      
        if (PlayerPrefs.GetInt("player") == 1)
        {
            player.SetActive(true);

        }
        else if (PlayerPrefs.GetInt("player") == 2)
        {
            player2.SetActive(true);

        }
        else if (PlayerPrefs.GetInt("player") == 3)
        {
            player3.SetActive(true);

        }
        enemies[Random.Range(0,3)].SetActive(true);
        
        StartCoroutine(kay());
    }
    public IEnumerator kay()
    {
     
        yield return new WaitForSeconds(3f);
        if (enemies[0].activeInHierarchy==true)
        {
            PlayerPrefs.SetInt("enemy", 1);
        }
        else if (enemies[1].activeInHierarchy == true)
        {
            PlayerPrefs.SetInt("enemy", 2);
        }
        else if (enemies[2].activeInHierarchy == true)
        {
            PlayerPrefs.SetInt("enemy", 3);
        }

       
        SceneManager.LoadScene(1);
    }
    
}
