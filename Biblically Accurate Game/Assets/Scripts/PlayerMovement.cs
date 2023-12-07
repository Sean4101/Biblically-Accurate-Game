using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    public float movenentSpeed = 5f;

    bool isRolling = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        CheckInput();
    }

    private void FixedUpdate()
    {
        if (!isRolling)
            Move();
    }

    void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Roll();
        }
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(x, y);
        movement.Normalize();

        rb.velocity = movement * movenentSpeed;
    }

    void Roll()
    {
        // To be implemented
    }
}
