using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody2D rb;
    private Animator animator;

    public float dashDistance = 2; 
    private float dashCooldown = 1.5f; 
    private float nextDashTime = 0f; 

    private bool isDashing = false; 
    private Vector2 dashDirection; 

    public Shader motionBlurShader;

    public float blurStrength;
    private Dictionary<Renderer, Shader> originalShaders = new Dictionary<Renderer, Shader>();
    public MotionBlurEffect cameraBlurEffect;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isDashing)
            return;
            
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        Vector2 moveInput = new Vector2(moveX, moveY);
        Vector2 moveVelocity = moveInput.normalized * speed;

        if (moveVelocity != Vector2.zero)
        {
            if (moveX > 0)
            {
                transform.localScale = new Vector3(1, 1, 1); 
            }
            else if (moveX < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1); 
            }
            animator.SetBool("IsWalking", true);
        }
        else
        {
            moveVelocity = Vector2.zero; 
            animator.SetBool("IsWalking", false);
        }

        rb.velocity = moveVelocity;

        if (Input.GetKeyDown(KeyCode.LeftShift) && dashDistance > 0 && Time.time > nextDashTime)
        {
            dashDirection = moveInput; 
            if (dashDirection != Vector2.zero)
            {
                StartDash(moveInput);
                nextDashTime = Time.time + dashCooldown; // set next dash time
            }
        }
    }

    private void StartDash(Vector2 moveInput)
    {
        isDashing = true;

        dashDirection = moveInput.normalized;

        cameraBlurEffect.blurAmount = blurStrength;
        cameraBlurEffect.blurDirection = dashDirection;


        StartCoroutine(DashCoroutine());
    }
    
    private IEnumerator DashCoroutine()
    {
        float startTime = Time.time;

        while (Time.time < startTime + 0.1f) // 0.1f is time of dash
        {
            rb.velocity = dashDirection.normalized * dashDistance / 0.1f; 
            yield return null;
        }

        isDashing = false;
        
        cameraBlurEffect.blurAmount = 0;
    }
}
