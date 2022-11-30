using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float hlimit;
    public float hmin;
    public float vlimit;
    public float vmin;
    public Transform face;
    
    void Start()
    {
        SpawnFly();
    }

   
    void Update()
    {
        GameObject fly = ObjectPool.SharedInstance.GetPooledObject();
        if (fly != null)
        {
            //fly.transform.position = new Vector2(Random.Range(hmin, hlimit), Random.Range(vmin, vlimit));
            //fly.transform.rotation = Quaternion.identity;
            //fly.SetActive(true);
            SpawnFly();
        }

    }
    void SpawnFly()
    {
        GameObject fly = ObjectPool.SharedInstance.GetPooledObject();
        bool flySpawned = false;
        while (!flySpawned)
        {
            fly.transform.position = new Vector2(Random.Range(hmin, hlimit), Random.Range(vmin, vlimit));
            //fly.transform.rotation = Quaternion.identity;
            if ((fly.transform.position-face.localPosition).magnitude<1)
            {
                continue;
            }
            else
            {
                fly.transform.position = new Vector2(Random.Range(hmin, hlimit), Random.Range(vmin, vlimit));
                fly.transform.rotation = Quaternion.identity;
                fly.SetActive(true);
                flySpawned = true;
            }
               
        }

    }
}
