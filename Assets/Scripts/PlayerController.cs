using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumForce;
    private Rigidbody2D rb;
    public Animator aim;
    private bool isLadder;
    private bool isClimbing;
    private float inputvertical;
    public int score = 0;
    [SerializeField]
    private Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        aim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float inputhorizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(inputhorizontal * speed, rb.velocity.y);
        Vector3 charactesScale = transform.localScale;
        if (Input.GetAxis("Horizontal") < 0)
        {
            charactesScale.x = -1;
            aim.SetBool("Walk", true);
            aim.SetBool("Standing", false);
            aim.SetBool("Jumbing", false);
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            charactesScale.x = 1;
            aim.SetBool("Walk", true);
            aim.SetBool("Standing", false);
            aim.SetBool("Jumbing", false);
        }
        transform.localScale = charactesScale;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumForce, ForceMode2D.Impulse);
            charactesScale.x = -1;
            aim.SetBool("Walk", false);
            aim.SetBool("Standing", false);
            aim.SetBool("Jumbing", true);
        }
        if (Input.GetAxis("Horizontal") == 0)
        {
            aim.SetBool("Walk", false);
            aim.SetBool("Standing", true);
            aim.SetBool("Jumbing", false);
        }
        inputvertical = Input.GetAxisRaw("Vertical");
        if (isLadder && Mathf.Abs(inputvertical) > 0f)
        {
            isClimbing = true;
        }
    }
    private void FixedUpdate()
    {
        if (isClimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, inputvertical * speed);
        }
        else
        {
            rb.gravityScale = 1f;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = true;
        }
        if (collision.CompareTag("Gift"))
        {
            collision.gameObject.SetActive(false);
            score += 1;
            scoreText.text = "GOLD: " + score;
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