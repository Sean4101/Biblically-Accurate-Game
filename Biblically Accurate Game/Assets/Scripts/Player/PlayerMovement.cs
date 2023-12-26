using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Animator animator;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    PlayerStatus playerStatus;

    public bool canControl = true;

    [Header("Movement Stats")]
    public float movementSpeed = 5f;
    public float movementAcceleration = 60f;
    public float movementDeceleration = 60f;

    [Header("Roll Stats")]
    public float rollSpeed = 20f;
    public float rollDuration = 0.2f;
    public float rollAdditionalInvincibilityDuration = 0.1f;

    Vector2 movementDirection;
    bool isRolling = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        playerStatus = GetComponent<PlayerStatus>();
    }

    private void Update()
    {
        GetInput();
    }

    private void FixedUpdate()
    {
        if (!isRolling)
            Move();
    }

    void GetInput()
    {
        if (!canControl)
        {
            movementDirection = Vector2.zero;
            return;
        }
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        movementDirection = new Vector2(x, y);
        movementDirection.Normalize();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Roll();
        }
    }

    void Move()
    {
        if (movementDirection.magnitude > 0)
        {
            if (rb.velocity.magnitude < movementSpeed)
                rb.AddForce(movementAcceleration * movementDirection);
            else
                rb.velocity = movementDirection * movementSpeed;
            animator.SetBool("Walk", true);
        }
        else if (rb.velocity.magnitude > 0.1f)
        {
            rb.AddForce(-rb.velocity.normalized * movementDeceleration);
            animator.SetBool("Walk", false);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }

        if (movementDirection.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (movementDirection.x < 0)
        {
            spriteRenderer.flipX = true;
        }
    }

    void Roll()
    {
        StartCoroutine(RollCoroutine());
    }
    
    IEnumerator RollCoroutine()
    {
        //makes player roll in it's moving direction
        isRolling = true;
        playerStatus.SetInvincible(true);
        rb.velocity = movementDirection.normalized * rollSpeed;
        yield return new WaitForSeconds(rollDuration);
        isRolling = false;
        yield return new WaitForSeconds(rollAdditionalInvincibilityDuration);
        playerStatus.SetInvincible(false);
    }
}
