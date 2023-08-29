using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TreeEditor;
using UnityEditor;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Rorceground_1 : MonoBehaviour
{
    public GameObject pointG;
    public GameObject pointH;
    private Rigidbody2D rb;
    private Transform currentPoint;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = pointG.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if(currentPoint == pointG.transform) 
        {
            rb.velocity = new Vector2(speed, 0);
        }else
        {
            rb.velocity =  new Vector2(-speed, 0);
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointH.transform)
        {
            flip();
            currentPoint = pointG.transform;
        
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointG.transform)
        {
            flip();
            currentPoint = pointH.transform;
          
        }
    }
    private void flip()
    {
        Vector3 localscale = transform.localScale;
        localscale.x *= -1;
        transform.localScale = localscale;       
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointG.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointH.transform.position, 0.5f);
        Gizmos.DrawLine(pointH.transform.position, pointG.transform.position);
    }
}
