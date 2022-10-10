using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChracterController : MonoBehaviour
{

    [SerializeField] private float runSpeed = 8f;
    private float horizontal;
    [SerializeField] private float jumpingPower = 16f;
    [SerializeField] private bool isFacingRight = false;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;


    bool isTouchingFront;
    [SerializeField] private Transform frontCheck;
    bool wallSliding;
    [SerializeField] private float wallSlidingSpeed;

    bool wallJumping;
    [SerializeField] private float xWallForce;
    [SerializeField] private float yWallForce;
    [SerializeField] private float wallJumpTime;

    public bool isGroundedb;
    private bool inTheAir;

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        Flip();


        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonDown("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.y, rb.velocity.y * 0.5f);
        }

        isTouchingFront = Physics2D.OverlapCircle(frontCheck.position, 0.2f, groundLayer);

        if(isTouchingFront == true && isGrounded() == false && horizontal != 0)
        {
            wallSliding = true;
        }
        else
        {
            wallSliding = false;
        }

        if(wallSliding)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }

        if (Input.GetButtonDown("Jump") && wallSliding == true)
        {
            wallJumping = true;
            Invoke("setWallJumpingToFalse", wallJumpTime);
        }

        if(wallJumping)
        {
            rb.velocity = new Vector2(xWallForce * -horizontal, yWallForce);
        }

    }

    void setWallJumpingToFalse()
    {
        wallJumping = false;
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    void FixedUpdate()
    {
        //Move Character
        rb.velocity = new Vector2(horizontal * runSpeed, rb.velocity.y);
    }


    private void Flip()
    {
        if(isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
