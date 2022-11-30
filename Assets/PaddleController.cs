using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public Transform target;
    public float fRadius = 3.0f;
    private Transform pivot;
    void Update()
    {
        Vector3 v3Pos = Camera.main.WorldToScreenPoint(target.position);
        v3Pos = Input.mousePosition - v3Pos;
        float angle = Mathf.Atan2(v3Pos.y, v3Pos.x) * Mathf.Rad2Deg;
        v3Pos = Quaternion.AngleAxis(angle, Vector3.forward) * (Vector3.right * fRadius);
        transform.position = target.position + v3Pos;
        //public Transform orb;
        //public float radius;



        //void Start()
        //{
        //    //pivot = orb.transform;
        //    //transform.parent = pivot;
        //    //transform.position += Vector3.up * radius;
        //}

      
            pivot = target.transform;
            transform.parent = pivot;
            transform.position += Vector3.up * fRadius;
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 orbVector = Camera.main.WorldToScreenPoint(target.position);
                orbVector = Input.mousePosition - orbVector;
                float angle2 = Mathf.Atan2(orbVector.y, orbVector.x) * Mathf.Rad2Deg;
                pivot.position = target.position;
                pivot.rotation = Quaternion.AngleAxis(angle2 - 90, Vector3.forward);

            }
            //DetectSwipe();

        //public void DetectSwipe()
        //{


        //    if (Input.GetMouseButtonUp(0))
        //    {
        //        //pivot.position = Vector3.zero;
        //        //pivot.rotation = Quaternion.identity;
        //    }
    }
}
