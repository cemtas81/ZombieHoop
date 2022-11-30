using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRibound : MonoBehaviour
{
    public GameObject ball;
    public GameObject ball2;
    public GameObject ball3;
    public GameObject urBall;
    public GameObject urBall2;
    public GameObject urBall3;
    public GameObject hand;
    public GameObject hand2;
    public GameObject hand3;
    public GameObject rebound;
    public GameObject rebound2;
    public GameObject rebound3;
   
   
    void Start()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == ball || collision.gameObject == ball2 || collision.gameObject == ball3)
        {
            ball.SetActive(false);
            ball2.SetActive(false);
            ball3.SetActive(false);
            urBall.SetActive(true);
            urBall2.SetActive(true);
            urBall3.SetActive(true);
            hand.SetActive(false);
            hand2.SetActive(false);
            hand3.SetActive(false);
            rebound.SetActive(true);
            rebound2.SetActive(true);
            rebound3.SetActive(true);
            
           
        }
    }
   
}
