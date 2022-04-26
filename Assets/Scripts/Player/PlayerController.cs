using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator), typeof(SpriteRenderer))]
public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sr;

    public float speed;
    public int jumpForce;
    public bool isGrounded;
    public LayerMask isGroundLayer;
    public Transform groundCheck;
    public float groundCheckRadius;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

        //Could be used as a double check to ensure groundcheck is set if we are null.
        if (!groundCheck)
        {
            groundCheck = GameObject.FindGameObjectWithTag("Ground Check").transform;
        }

        if (speed <= 0)
        {
            speed = 5.0f;
        }

        if (jumpForce <= 0)
        {
            jumpForce = 300;
        }

        if (groundCheckRadius <= 0)
        {
            groundCheckRadius = 0.2f;
        }

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        AnimatorClipInfo[] curPlayingClip = anim.GetCurrentAnimatorClipInfo(0);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, isGroundLayer);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * jumpForce);
        }
        if (curPlayingClip.Length > 0)
        {
            if (curPlayingClip[0].clip.name != "Fire")
            {
                Vector2 moveDirection = new Vector2(horizontalInput * speed, rb.velocity.y);
                rb.velocity = moveDirection;
            }
            else
            {
                rb.velocity = Vector2.zero;
            }
        }
         

        anim.SetFloat("speed", Mathf.Abs(horizontalInput));
        anim.SetBool("isGrounded", isGrounded);

        //check for flipped
        //if (horizontalInput > 0 && sr.flipX || horizontalInput < 0 && !sr.flipX )
        //    sr.flipX = !sr.flipX;

        if (horizontalInput != 0)
            sr.flipX = (horizontalInput < 0);

        //sr.flipX = (horizontalInput < 0) ? true : (horizontalInput > 0) ? false : sr.flipX;

    }
}
