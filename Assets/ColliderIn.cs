using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderIn : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        PolygonCollider2D circle = GetComponent<PolygonCollider2D>();
        if (circle==null)
        {
            circle = gameObject.AddComponent<PolygonCollider2D>();
        }
        Vector2[] points = circle.points;
        EdgeCollider2D edge = gameObject.AddComponent<EdgeCollider2D>();
        edge.points = points;
        Destroy(circle);
    }


}
