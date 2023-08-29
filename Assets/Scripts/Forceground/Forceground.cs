using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Forceground : MonoBehaviour
{
    public GameObject pointE;
    public GameObject pointF;
    private Rigidbody2D rb;
    private Transform currentPoint;

    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = pointE.transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if (currentPoint == pointE.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else  
        {
            rb.velocity =  new Vector2 (-speed, 0);
        }
        if(Vector2.Distance(transform.position, currentPoint.position)< 0.5f && currentPoint == pointF.transform) 
        {
            Flip();
            currentPoint = pointE.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointE.transform)
        {
            Flip();
            currentPoint = pointF.transform;
        }

    }
    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointE.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointF.transform.position, 0.5f);
        Gizmos.DrawLine(pointE.transform.position, pointF.transform.position);
    }
}
