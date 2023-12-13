using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    [Header("Movement Stats")]
    public float movenentSpeed = 5f;
    public float movementAcceleration = 60f;
    public float movementDeceleration = 60f;
    public float rollSpeed = 20f;
    public float rollDuration = 0.2f;

    Vector2 movementDirection;
    bool isRolling = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
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
            if (rb.velocity.magnitude < movenentSpeed)
                rb.AddForce(movementAcceleration * movementDirection);
            else
                rb.velocity = movementDirection * movenentSpeed;
        }
        else if (rb.velocity.magnitude > 0.1f)
        {
            rb.AddForce(-rb.velocity.normalized * movementDeceleration);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    void Roll()
    {
        StartCoroutine(RollCoroutine());
    }

    IEnumerator RollCoroutine()
    {
        isRolling = true;
        Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 rollDirection = cursorPosition - (Vector2)transform.position;
        rb.velocity = rollDirection.normalized * rollSpeed;
        yield return new WaitForSeconds(rollDuration);
        isRolling = false;
    }
}
