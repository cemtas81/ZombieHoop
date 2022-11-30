using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Translate2 : MonoBehaviour
{
    public GameObject cam2;
    public GameObject scope;
    private Vector3 mousePos;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnMouseDown()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePos.x, mousePos.y, 0);
    }
     void OnMouseUp()
    {
        cam2.SetActive(false);
    }
    private void OnMouseDrag()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePos.x, mousePos.y, 0);
    }

}
