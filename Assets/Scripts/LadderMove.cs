using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderMove : MonoBehaviour
{
    private float speed = 100;
    private bool isLadder;
    private bool isClimbing;
    [SerializeField] private Rigidbody2D rb;
    private float inputvertical;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputvertical = Input.GetAxis("Vertical");
        if (isLadder && Mathf.Abs(inputvertical) > 0f)
        {
            isClimbing = true;
        }
    }
    private void FixedUpdate()
    {
        if(isClimbing) 
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, inputvertical * speed);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;
        }

    }
}
