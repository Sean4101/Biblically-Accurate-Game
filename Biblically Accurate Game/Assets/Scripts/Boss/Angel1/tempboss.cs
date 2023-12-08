using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class tempboss : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int boss_health = 100;

    private int timer = 0; // Initial timer duration
    private bool isTimerRunning = false;
    private bool shouldSpin = true;
    public float rotationSpeed = 45f;

    //set a timer for the boss to attack
    
    void Start()
    {
        StartTimer();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("we are collided");
        //boss_health -= 10;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log("we are still colliding");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("we are no longer colliding");
    }


    void StartTimer()
    {
        if (!isTimerRunning)
        {
            StartCoroutine(CountupTimer());
        }
    }

    IEnumerator CountupTimer()
    {
        isTimerRunning = true;

        while (true) // Infinite loop for counting up
        {
            yield return new WaitForSeconds(1f); // Wait for 1 second
            timer++;

            // You can do something each second (e.g., update a display)
            //Debug.Log("Time elapsed: " + timer + " seconds");
        }

        // Note: The loop will continue indefinitely until you stop the coroutine or the game ends
    }

    // You can stop the timer by calling this method
    void StopTimer()
    {
        StopCoroutine(CountupTimer());
        isTimerRunning = false;
    }

    void TakeDamage(int damage)
    {
        //Debug.Log("boss took damage");
        boss_health -= damage;
        if (boss_health <= 0)
        {
            //Die();
        }
    }

}

