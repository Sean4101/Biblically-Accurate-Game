using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class tempboss_weapon : MonoBehaviour
{   
    public GameObject je_sus;
    public GameObject poopoo;

    //public Transform firePoint;
    public GameObject player;
    public Transform firepoint;
    public float boss_fireforce = 20f;

    public float speed;

    public float rotationModifier;

    System.Random rngatk = new System.Random((int)DateTime.Now.Ticks);
    private int atk = 0;
    private int timer = 0; // Initial timer duration
    private int duration = 0;
    public int cooldown = 0;
    private bool isTimerRunning = false;

    private void Start()
    {
        StartTimer();
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {

        if (player != null)
        {
            Vector3 vectorToTarget = player.transform.position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - rotationModifier;
            Quaternion q = Quaternion.AngleAxis(angle-80, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
           
            //firepoint points as the same direction as rotation
            firepoint.rotation = Quaternion.Slerp(firepoint.rotation, q, Time.deltaTime * speed);

        }


        atk = rngatk.Next(0, 3);
        cooldown = rngatk.Next(5, 20);

        if (duration == cooldown)
        {
            if (atk == 0)
            {
                Debug.Log("poopoo go!");
                GameObject projectile1 = Instantiate(poopoo, firepoint.position, firepoint.rotation);
                projectile1.GetComponent<Rigidbody2D>().AddForce(firepoint.up * boss_fireforce, ForceMode2D.Impulse);
                cooldown = 0;
            }
            else if (atk == 1)
            {
                Debug.Log("je_sus go!");
                GameObject projectile2 = Instantiate(je_sus, firepoint.position, firepoint.rotation);
                projectile2.GetComponent<Rigidbody2D>().AddForce(firepoint.up * boss_fireforce, ForceMode2D.Impulse);
                cooldown = 0;
            }

        }

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
            duration++;

            // You can do something each second (e.g., update a display)
            Debug.Log("Time elapsed: " + timer + " seconds");
        }

        // Note: The loop will continue indefinitely until you stop the coroutine or the game ends
    }

    // You can stop the timer by calling this method
    void StopTimer()
    {
        StopCoroutine(CountupTimer());
        isTimerRunning = false;
    }

}
