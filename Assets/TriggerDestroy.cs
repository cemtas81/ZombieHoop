using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDestroy : MonoBehaviour
{
    public Collider2D eye1;
    public Collider2D eye2;
    private bool yes;
    private bool yes2;
    public Transform face;
    public GameObject nose;
    public GameObject tryagain;
 
    void Start()
    {
        yes = false;
        yes2 = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision==eye1)
        {
            yes = true;
        }
        if (collision == eye2)
        {
            yes2 = true;
        }
       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision == eye1)
        {
            yes = false;
        }
        if (collision == eye2)
        {
            yes2 = false;
        }
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, face.position, Random.Range(0.07f,0.5f)*Time.deltaTime);
        //transform.up = face.position;
        
        if (yes==true&&yes2==true)
        {
            this.gameObject.SetActive(false);
        }
        if (transform.position==face.position&&this.gameObject.activeInHierarchy)
        {
        
                StartCoroutine(sokma());
      
        }
    }
    IEnumerator sokma()
    {
     
        yield return new WaitForSeconds(3);
        nose.SetActive(false);
        tryagain.SetActive(true);
    }
}
