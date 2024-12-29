using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMove : MonoBehaviour
{
    private Rigidbody2D rigid;
    public float speed;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //var direction = Vector2.zero;
        //rigid.AddRelativeForce(Vector2.left * speed * Time.deltaTime, ForceMode2D.Force);
        //direction = target.transform.position - transform.position;
        //rigid.AddRelativeForce(direction.normalized * speed, ForceMode2D.Force);
        var dif = target.transform.position - transform.position;
        if (dif.magnitude > 1)
        {
            rigid.AddForce(dif * speed * Time.deltaTime);
        }
        else
        {
            rigid.linearVelocity = Vector2.zero;
        }
    }
    private void Update()
    {
        //transform.LookAt(target.transform.position);
        //Vector2 direction = (target.transform.position - transform.position).normalized;
        //rigid.MovePosition(transform.position + direction * speed * Time.deltaTime);
    }


}
