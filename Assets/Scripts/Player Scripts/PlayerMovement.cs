using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public float MovementSpeed;
    public Rigidbody2D rb;
    public HealthSystem healthSystem;

    public float JumpForce = 20f;
    public Transform feet;
    public LayerMask groundLayers;
    public Animator animator;

    float mx;

    private bool canDash = true;
    private bool isDashing;
    private float DashingPower = 50f;
    private float DashingTime = 0.2f;
    private float DashingCoolDown = 1f;
    private bool IsFacingRight = true;
    public AudioSource audioSource;
    private bool IsMoving = false;

    

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    private void Update()
    {
        if(isDashing)
        {
            return;
        }
        Flip();
        //Movement
        mx = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(mx));
        //Jump
        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
            animator.SetBool("IsJumping", true);
            
        }
        if(Input.GetButtonUp("Jump"))
        {
            animator.SetBool("IsJumping", false);
            
        }
        //Dash
        if(Input.GetKeyDown(KeyCode.Mouse1) && canDash)
        {
            StartCoroutine(Dash());
        }
        //Movement Audio
        if (GetComponent<Rigidbody2D>().velocity.magnitude > 0 && !IsMoving)
        {
            //audioSource.Play();
            IsMoving = true;
        }
        if (GetComponent<Rigidbody2D>().velocity.magnitude == 0 && IsMoving)
        {
            //audioSource.Stop();
            IsMoving = false;
        }

    }


    private void FixedUpdate()
    {
        if(isDashing)
        {
            return;
        }
               
        Vector2 movement = new Vector2(mx * MovementSpeed, rb.velocity.y);
        rb.velocity = movement;
        
    }
    void Jump()
    {
        Vector2 movement = new Vector2(rb.velocity.x , JumpForce);
        
        rb.velocity = movement;
    }
    public bool IsGrounded ()
    {
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.5f, groundLayers);

        if(groundCheck != null)
        {
            return true;
            
        }       
        return false;

    }
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * DashingPower, 0f);
        IsDashing(true);
        //tr.emitting = true;
        yield return new WaitForSeconds(DashingTime);
        //tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        IsDashing(false);
        yield return new WaitForSeconds(DashingCoolDown);
        canDash = true;
    }
    private void Flip()
    {
        if(IsFacingRight && mx < 0f || !IsFacingRight && mx > 0f)
        {
            IsFacingRight = !IsFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "NextLvlPortal")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if(collision.tag == "Bullet")
        {
            healthSystem.TakeDamage(1);
        }
    }

    public void IsLanding(bool dec)
    {
        animator.SetBool("IsJumping", dec);
    }

    public void IsDashing(bool dec)
    {
        animator.SetBool("IsDashing", dec);
    }
    
    


}
