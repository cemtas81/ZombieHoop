using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallInHole : MonoBehaviour
{
    public Transform delik;
    public GameObject ball;
    public GameObject eight;
    private Rigidbody2D rig;
    private void Start()
    {
        rig = ball.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject==ball)
        {
            rig.velocity = Vector2.zero;
            ball.transform.position = delik.position;
        }
        if (collision.gameObject==eight)
        {
            SceneManager.LoadScene(0);
        }
    }
   
  
}
