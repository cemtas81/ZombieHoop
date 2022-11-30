using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class BasicTake : MonoBehaviour
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
   
    public GameObject flame;
    
    
    
    // Start is called before the first frame update
    void Start()
    {

        topRigid = GetComponent<Rigidbody2D>();
        
        lr = GetComponent<LineRenderer>();
        pivot = transform;
        but.onClick.AddListener(level);
       
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
        SceneManager.LoadScene(0);
        Debug.Log("geri");
    }

    public static Swipe swipeDirection;

    void Update()
    {
        
            DetectSwipe();
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

            //secondClickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            secondClickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentSwipe = new Vector2(secondClickPos.x - firstClickPos.x, secondClickPos.y - firstClickPos.y);
            //topRigid.AddForce(Vector2.MoveTowards(top.transform.position, currentSwipe, speed * -1), ForceMode2D.Impulse);
            Vector2 _velocity = currentSwipe * speed;
            topRigid.velocity = _velocity * -1;
            istaka.transform.parent = null;
            //joint.enabled = false;

            lr.positionCount = 0;
            if (flame != null)
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

            currentSwipe = new Vector2(secondClickPos.x - firstClickPos.x, secondClickPos.y - firstClickPos.y);
            secondClickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 _velocity = (currentSwipe * speed) * -1;
            Vector2[] trajectory = Plot(topRigid, (Vector2)transform.position, _velocity, 500);
            lr.positionCount = trajectory.Length;
            Vector3[] positions = new Vector3[trajectory.Length];
            for (int i = 0; i < trajectory.Length; i++)
            {
                positions[i] = trajectory[i];
            }
            lr.SetPositions(positions);

           

            //if (istaka != null)
            //{

            //    istaka.transform.position = new Vector3(currentSwipe.x, 0, -1) * speed;
            //    istaka.transform.parent = pivot;

            //    istaka.transform.position += Vector3.left * radius;
            //    Vector3 orbVector = Camera.main.WorldToScreenPoint(transform.position);
            //    orbVector = Input.mousePosition - orbVector;
            //    float angle = Mathf.Atan2(orbVector.y, orbVector.x) * Mathf.Rad2Deg;

            //    pivot.position = transform.position;
            //    pivot.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            //    //istaka.transform.position = new Vector3(transform.position.x, transform.position.y + 5,-1);

            //}
            if (istaka == null)
            {
                Debug.Log("yok");
            }

        }

    }
    public Vector2[] Plot(Rigidbody2D rigidbody, Vector2 pos, Vector2 velocity, int steps)
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
        if (flame != null)
        {
            flame.SetActive(false);
        }

    }
}
