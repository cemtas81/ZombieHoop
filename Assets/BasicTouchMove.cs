using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

using UnityEngine.SceneManagement;
public enum Swipe {None,Up,Down,Right,Left };
public class BasicTouchMove : MonoBehaviour
{
    private GameObject top;
    private Rigidbody2D topRigid;
    public float speed;
    private LineRenderer lr;
    private Vector2 mousepos;
    public float minSwipeLength = 5f;
    public float maxSwipeLength = 25f;
    public GameObject istaka;
    Vector2 currentSwipe;
    private Transform pivot;
    Vector2 firstClickPos;
    Vector2 secondClickPos;
    public float radius;
    public Button but;
    public SpriteRenderer head;
    public GameObject flame;
    public GameObject ball;
    public GameObject hand;
    private CircleCollider2D col;
    public bool yerde;
   
    //private HingeJoint2D joint;
    // Start is called before the first frame update
    void Start()
    {
       
        topRigid = GetComponent<Rigidbody2D>();
        col = GetComponent<CircleCollider2D>();
        lr = GetComponent<LineRenderer>();
        pivot = transform;
        but.onClick.AddListener(level);
        //joint = ball.GetComponent<HingeJoint2D>();
        lr.positionCount = 0;
    }
  
    private void level()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(0))
        {
            SceneManager.LoadScene(1);
        }
        else
           
        PlayerPrefs.SetInt("player", 0);
        PlayerPrefs.Save();
        Debug.Log("geri");
        SceneManager.LoadScene(0);
    }
    
    public static Swipe swipeDirection;

    void Update()
    {
        //if (joint.enabled==true)
        //{
        //    DetectSwipe();
        //}
        if (transform.position.y <= 0.5)
        {
            yerde = true;
        }
        if (transform.position.y >= 0.5)
        {
            yerde = false;
        }

        if (yerde == true)
        {
            DetectSwipe();
        }
        //DetectSwipe();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PlayerPrefs.SetInt("player", 0);
            PlayerPrefs.Save();
            SceneManager.LoadScene(0);
            Debug.Log("geri");
        }
    }

    public void DetectSwipe()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //firstClickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            firstClickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
           
        }
        else
        {
            swipeDirection = Swipe.None;
           
        }
        if (Input.GetMouseButtonUp(0))
        {
            lr.positionCount = 0;

            //secondClickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            secondClickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentSwipe = new Vector2(secondClickPos.x - firstClickPos.x, secondClickPos.y - firstClickPos.y);
            //topRigid.AddForce(Vector2.MoveTowards(top.transform.position, currentSwipe, speed * -1), ForceMode2D.Impulse);
            Vector2 _velocity = currentSwipe * speed;
           
            istaka.transform.parent = null;
            //if (ball.transform.position.x<=2)
            //{
            //    joint.enabled = false;
            //    hand.SetActive(true);
            //}
            if (_velocity.magnitude>=maxSwipeLength)
            {
                topRigid.velocity = new Vector2(_velocity.x * -0.5f, 0);
            }
            else 
           
                topRigid.velocity = _velocity * -1;
            

            if (flame != null&&yerde==true)
            {
                flame.SetActive(true);
            }
          

           

            if (currentSwipe.magnitude < minSwipeLength)
            {
                swipeDirection = Swipe.None;
                return;
            }

          

            currentSwipe.Normalize();

            
        }
        
        
        if (Input.GetMouseButton(0))
        {
            secondClickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentSwipe = new Vector2(secondClickPos.x - firstClickPos.x, secondClickPos.y - firstClickPos.y);
           
            Vector2 _velocity = (currentSwipe * speed)*-1;

            Vector2[] trajectory = Plot(topRigid, (Vector2)transform.position, _velocity, 500);
           
            lr.positionCount = trajectory.Length;
            Vector3[] positions = new Vector3[trajectory.Length];
            for (int i = 0; i < trajectory.Length; i++)
            {
                positions[i] = trajectory[i];
            }
            if (yerde == true&& _velocity.magnitude <= maxSwipeLength)
            {
                lr.SetPositions(positions);
            }
            else
                lr.positionCount = 0;
            
            if (currentSwipe.x > 0)
            {
               
                head.flipX = true;
            }
            if (currentSwipe.x < 0)
            {

                head.flipX = false;
            }


           

        }

    }
    public Vector2[] Plot(Rigidbody2D rigidbody,Vector2 pos,Vector2 velocity,int steps)
    {
        Vector2[] results = new Vector2[steps];

        float timestep = Time.fixedDeltaTime / Physics2D.velocityIterations;
        Vector2 gravityAccel = Physics2D.gravity * rigidbody.gravityScale * timestep * timestep;
        float drag = 1f - timestep * rigidbody.drag;
        Vector2 moveStep = velocity * timestep;
      
        for (int i = 0; i < steps; i++)
        {
            moveStep += gravityAccel;
            moveStep *= drag;
            pos += moveStep;
            results[i] = pos;
        }
        return results;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (flame!=null)
        {
            flame.SetActive(false);
        }
        
    }
   
}
