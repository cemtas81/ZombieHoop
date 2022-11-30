using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using MoreMountains.NiceVibrations;
public class CharSelect : MonoBehaviour
{
    public GameObject top;
    public TextMeshProUGUI Text;
    public TextMeshProUGUI Text2;
    public float speed;
    public string ad;
    public float minSwipeLength = 5f;
    public float maxSwipeLength = 25f;
    Vector2 currentSwipe;
    public GameObject playerselect;
    public GameObject nick;
    Vector2 firstClickPos;
    Vector2 secondClickPos;
    public float radius;
    public Animation ani1;
    public Animation ani2;
    public Animation ani3;
    public float movetime = 5f;
    private bool ismoving ;
    private Vector2 orgpos, targetpos;
    public GameObject vs;
    //public NewAd add;
    // Start is called before the first frame update
    public void Start()
    {
        
        if (PlayerPrefs.GetInt("player")!=0)
        {
            playerselect.SetActive(false);
            nick.SetActive(false);
            vs.SetActive(true);
            ad = PlayerPrefs.GetString("nicko");
            Text.text = ad;
            Text2.text = ad;

        }
        if (PlayerPrefs.GetInt("Sound") == 1)
        {
            AudioListener.pause = true;
           
        }
        if (PlayerPrefs.GetInt("Sound") == 0)
        {
            AudioListener.pause = false;
           
        }
        if (PlayerPrefs.GetInt("Vib") == 1)
        {
            MMVibrationManager.SetHapticsActive(false);
            
        }
        if (PlayerPrefs.GetInt("Vib") == 0)
        {
            MMVibrationManager.SetHapticsActive(true);
           
        }


    }

    public static Swipe swipeDirection;

    public void Update()
    {
       
         if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            Debug.Log("çık");
        }
       
        DetectSwipe();

        Text2.text = Text.text;
       

    }
   

    public void DetectSwipe()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firstClickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (ismoving == false)
            {
                Ray raycast = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit raycastHit;

                if (Physics.Raycast(raycast, out raycastHit))
                {
                    if (raycastHit.collider.CompareTag("zombik1"))
                    {
                        PlayerPrefs.SetInt("player", 1);
                       
                        StartCoroutine(level());
                       
                    }
                    if (raycastHit.collider.CompareTag("zombik2"))
                    {
                        PlayerPrefs.SetInt("player", 2);
                        
                        StartCoroutine(level());
                    }
                    if (raycastHit.collider.CompareTag("zombik3"))
                    {
                        PlayerPrefs.SetInt("player", 3);
                       
                        StartCoroutine(level());
                    }
                }
            }
        }
        else
        {
            swipeDirection = Swipe.None;

        }
        if (Input.GetAxis("Mouse X")>1||Input.GetAxis("Mouse X")<-1)
        {


            secondClickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentSwipe = new Vector2(secondClickPos.x - firstClickPos.x, secondClickPos.y - firstClickPos.y);




            if (currentSwipe.magnitude < minSwipeLength)
            {
                swipeDirection = Swipe.None;
                return;
            }

            currentSwipe.Normalize();

            if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
            {
                swipeDirection = Swipe.Up;
                Debug.Log("Up");

            }
            else if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
            {
                swipeDirection = Swipe.Down;
                Debug.Log("Down");

            }
            else if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f && !ismoving)
            {
                if (top.transform.position.x > -7 && ismoving == false)
                {
                    swipeDirection = Swipe.Left;
                    Debug.Log("Left");
                    StartCoroutine(Move(Vector2.left * 14));
                }
            }
            else if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
            {
                if (top.transform.position.x < 7 && ismoving == false)
                {
                    swipeDirection = Swipe.Right;
                    Debug.Log("right");
                    StartCoroutine(Move(Vector2.right * 14));
                }

            }
        }
    }
   
    private IEnumerator level()
    {
        ani3.Play();
        ani2.Play();
        ani1.Play();
        MMVibrationManager.Haptic(HapticTypes.MediumImpact);
        ismoving = true;
        yield return new WaitForSeconds(1f);
       
        playerselect.SetActive(false);
        nick.SetActive(true);
       

    }
   private IEnumerator Move(Vector2 direction)
    {
        ismoving = true;
        float elapsedtime = 0;
        orgpos = top.transform.position;
        targetpos = orgpos + direction;
        while (elapsedtime < movetime)
        {
            top.transform.position = Vector2.Lerp(orgpos, targetpos, (elapsedtime / movetime));
            elapsedtime += Time.deltaTime;
            yield return null;
        }
        
            top.transform.position = targetpos;
      
            ismoving = false;
        
        
    }
}