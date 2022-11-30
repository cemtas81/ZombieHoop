using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.AI;
using MoreMountains.NiceVibrations;

public class PotaCollider : MonoBehaviour
{
   
    public TMP_Text text;
    public int score;
    public int score2;
    public TMP_Text text2;
    private bool say2;
    private bool say;
    public GameObject particle1;
    public GameObject particle2;
    private ParticleSystem particl1;
    private ParticleSystem particl2;
    public GameObject player;
    public GameObject player2;
    public GameObject player3;
    public GameObject enemy;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemyBall;
    public GameObject enemyBall2;
    public GameObject enemyBall3;
    public GameObject ball;
    public GameObject ball2;
    public GameObject ball3;
    public GameObject hand;
    public GameObject hand2;
    public GameObject hand3;
    public GameObject enemyHand;
    public GameObject enemyHand2;
    public GameObject enemyHand3;
    public Transform side;
    public Transform enemySide;
    public AudioSource sfx;
    public AudioClip basket;
    public AudioClip basket2; 

    // Start is called before the first frame update
    void Start()
    {
        say2 = false;
        say = false;
        particl1 = particle1.GetComponent<ParticleSystem>();
        particl2 = particle2.GetComponent<ParticleSystem>();
      
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "delik")
        {
            say = true;
            
        }

        if (collision.tag == "Finish"&&say==true)
        {
            say = false;
            score += 1;
            text.text = score.ToString();
            particle1.SetActive(true);
            particl1.Play();
            MMVibrationManager.Haptic(HapticTypes.MediumImpact);
            sfx.PlayOneShot(basket);
            hand.SetActive(true);
            hand2.SetActive(true);
            hand3.SetActive(true);
            enemyHand.SetActive(false);
            enemyHand2.SetActive(false);
            enemyHand3.SetActive(false);
            enemyBall.SetActive(true);
            enemyBall2.SetActive(true);
            enemyBall3.SetActive(true);
            ball.SetActive(false);
            ball2.SetActive(false);
            ball3.SetActive(false);

        }
        if (collision.tag == "delik2")
        {
            say2 = true;
          
        }
        if (collision.tag == "Respawn"&&say2==true)
        {
            say2 = false;
            score2 += 1;
            text2.text = score2.ToString();
            particle2.SetActive(true);
            particl2.Play();
            MMVibrationManager.Haptic(HapticTypes.MediumImpact);
            sfx.PlayOneShot(basket2);
            hand.SetActive(false);
            hand2.SetActive(false);
            hand3.SetActive(false);
            enemyHand.SetActive(true);
            enemyHand2.SetActive(true);
            enemyHand3.SetActive(true);
            enemyBall.SetActive(false);
            enemyBall2.SetActive(false);
            enemyBall3.SetActive(false);
            ball.SetActive(true);
            ball2.SetActive(true);
            ball3.SetActive(true);

        }

    }
   
}
