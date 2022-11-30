using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LevelManager : MonoBehaviour
{
    public GameObject zombik1;
    public GameObject zombik2;
    public GameObject zombik3;
    public List<GameObject> enemies;
    public List<GameObject> stads;
    public TextMeshProUGUI text;
    public void Start()
    {
        text.text = PlayerPrefs.GetString("nicko");
        
        if (PlayerPrefs.GetInt("player")== 1)
        {
            zombik1.SetActive(true);
            
        }
        else if (PlayerPrefs.GetInt("player") == 2)
        {
            zombik2.SetActive(true);

        }
        else if (PlayerPrefs.GetInt("player") == 3)
        {
            zombik3.SetActive(true);

        }
        
        
            stads[Random.Range(0, 4)].SetActive(true);
            
        if (PlayerPrefs.GetInt("enemy")==1)
        {
            enemies[0].SetActive(true);
           
        }
        else if (PlayerPrefs.GetInt("enemy") == 2)
        {
            enemies[1].SetActive(true);

        }
        else if (PlayerPrefs.GetInt("enemy") == 3)
        {
            enemies[2].SetActive(true);

        }
        
    }
    
}
