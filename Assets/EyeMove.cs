using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EyeMove : MonoBehaviour
{
    private VariableJoystick joy;
    public Rigidbody2D rigid2;
    public Rigidbody2D rigid;
    public Button again;
    //public Collider2D eye1;
    //public Collider2D eye2;
    // Start is called before the first frame update
    void Start()
    {
        joy = GetComponentInChildren<VariableJoystick>();
        again.onClick.AddListener(tryagain);
    }
    void tryagain()
    {
        SceneManager.LoadScene(0);
    }
    private void FixedUpdate()
    {
        rigid.AddForce(transform.up * joy.Vertical * Time.deltaTime / 1.5f, ForceMode2D.Impulse);
        rigid2.AddForce(transform.up * joy.Vertical * -1 * Time.deltaTime / 1.5f, ForceMode2D.Impulse);
        rigid.AddForce(transform.right * joy.Horizontal * -1 * Time.deltaTime / 2, ForceMode2D.Impulse);
        rigid2.AddForce(transform.right * joy.Horizontal * Time.deltaTime / 2, ForceMode2D.Impulse);


    }

}
