using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    [Header("Movement Stats")]
    public float movenentSpeed = 5f;

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
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        movementDirection = new Vector2(x, y);
        movementDirection.Normalize();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Roll();
        }
    }

    void Move()
    {
        rb.velocity = movementDirection * movenentSpeed;
    }

    void Roll()
    {
        // To be implemented
    }
}
