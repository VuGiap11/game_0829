using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockController : MonoBehaviour
{
    public GameObject pointC;
    public GameObject pointD;
    private Rigidbody2D rb;
    private Transform currentPoint;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = pointC.transform;
    }

    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if (currentPoint == pointD.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.2f && currentPoint == pointD.transform)
        {
            flip();
            currentPoint = pointC.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.2f && currentPoint == pointC.transform)
        {
            flip();
            currentPoint = pointD.transform;
        }
    }
    private void flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;

    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointC.transform.position, 0.2f);
        Gizmos.DrawWireSphere(pointD.transform.position, 0.2f);
        Gizmos.DrawLine(pointC.transform.position, pointD.transform.position);
    }
}
