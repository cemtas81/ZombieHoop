using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    
    private Rigidbody2D topRigid;
    public float speed;
    private LineRenderer lr;
    
    public float minSwipeLength = 5f;
    public float maxSwipeLength = 25f;
    public GameObject ball;
    Vector2 currentSwipe;
    public GameObject ribound;
    Vector2 firstClickPos;
    Vector2 secondClickPos;
    public float radius;
    private GameObject target;
    public SpriteRenderer head;
    public GameObject flame;
    private float elapsed;
    public GameObject ribound2;
    private CircleCollider2D col;
    private bool yerde;
    void Start()
    {
        topRigid = GetComponent<Rigidbody2D>();
        col = GetComponent<CircleCollider2D>();
        lr = GetComponent<LineRenderer>();
        elapsed = 0;
        speed += PlayerPrefs.GetInt("level") * 0.01f;
    }
   
    
    


    public static Swipe swipeDirection;

    void Update()
    {
        if (ball.activeInHierarchy == true)
        {
            target = ribound2;
            if (transform.position == ribound2.transform.position)
            {
                target = ribound;
            }
        }
        else
            target = GameObject.FindGameObjectWithTag("Top");

        elapsed += Time.deltaTime;
        if (elapsed >= 1.1f)
        {
            elapsed = elapsed % 7f;
            if (transform.position.y <= 1.7)
            {
                yerde = true;
            }
            if (transform.position.y >= 1.7)
            {
                yerde = false;
            }

            if (yerde == true)
            {
                OutputTime();
            }
           
        }
       
    }
    void OutputTime()
    {
        firstClickPos = transform.position;

        secondClickPos = target.transform.position;
        currentSwipe = new Vector2(secondClickPos.x - firstClickPos.x, secondClickPos.y - firstClickPos.y);

        Vector2 _velocity = currentSwipe * speed;
        if (_velocity.magnitude >= maxSwipeLength)
        {
            topRigid.linearVelocity = new Vector2(_velocity.x , 0);
        }
        else
        topRigid.linearVelocity = _velocity;

      
        //flame.SetActive(true);
        if (currentSwipe.x > 0)
        {

            head.flipX = false;
        }
        if (currentSwipe.x < 0)
        {

            head.flipX = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision==ribound2)
        {
            target = ribound;
        }
    }
    public void DetectSwipe()
    {

        //firstClickPos = transform.position;

        //secondClickPos = target.transform.position;
        //currentSwipe = new Vector2(secondClickPos.x - firstClickPos.x, secondClickPos.y - firstClickPos.y);

        //Vector2 _velocity = currentSwipe * speed;
        //topRigid.velocity = _velocity;

        //lr.positionCount = 0;




    }


    //    if (Input.GetMouseButton(0))
    //    {

    //        currentSwipe = new Vector2(secondClickPos.x - firstClickPos.x, secondClickPos.y - firstClickPos.y);
    //        secondClickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //        Vector2 _velocity = (currentSwipe * speed) * -1;
    //        Vector2[] trajectory = Plot(topRigid, (Vector2)transform.position, _velocity, 500);
    //        lr.positionCount = trajectory.Length;
    //        Vector3[] positions = new Vector3[trajectory.Length];
    //        for (int i = 0; i < trajectory.Length; i++)
    //        {
    //            positions[i] = trajectory[i];
    //        }
    //        lr.SetPositions(positions);

    //        if (currentSwipe.x > 0)
    //        {

    //            head.flipX = true;
    //        }
    //        if (currentSwipe.x < 0)
    //        {

    //            head.flipX = false;
    //        }


    //        if (istaka != null)
    //        {

    //            istaka.transform.position = new Vector3(currentSwipe.x, 0, -1) * speed;
    //            istaka.transform.parent = pivot;

    //            istaka.transform.position += Vector3.left * radius;
    //            Vector3 orbVector = Camera.main.WorldToScreenPoint(transform.position);
    //            orbVector = Input.mousePosition - orbVector;
    //            float angle = Mathf.Atan2(orbVector.y, orbVector.x) * Mathf.Rad2Deg;

    //            pivot.position = transform.position;
    //            pivot.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    //            //istaka.transform.position = new Vector3(transform.position.x, transform.position.y + 5,-1);

    //        }
    //        if (istaka == null)
    //        {
    //            Debug.Log("yok");
    //        }

    //    }

    //}
    //public Vector2[] Plot(Rigidbody2D rigidbody, Vector2 pos, Vector2 velocity, int steps)
    //{
    //    Vector2[] results = new Vector2[steps];

    //    float timestep = Time.fixedDeltaTime / Physics2D.velocityIterations;
    //    Vector2 gravityAccel = Physics2D.gravity * rigidbody.gravityScale * timestep * timestep;
    //    float drag = 1f - timestep * rigidbody.drag;
    //    Vector2 moveStep = velocity * timestep;

    //    for (int i = 0; i < steps; i++)
    //    {
    //        moveStep += gravityAccel;
    //        moveStep *= drag;
    //        pos += moveStep;
    //        results[i] = pos;
    //    }
    //    return results;

    //}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        flame.SetActive(false);
    }
}
