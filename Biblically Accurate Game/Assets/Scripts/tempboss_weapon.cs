using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class tempboss_weapon : MonoBehaviour
{   
   
    public GameObject poopoo;

    //public Transform firePoint;
    public GameObject player;
    public Transform firepoint;
    public float boss_fireforce = 20f;

    public float speed;

    public float rotationModifier;

    System.Random rngatk = new System.Random((int)DateTime.Now.Ticks);
    public GameObject aura;
    private int atk = 0;
    private int timer = 0; // Initial timer duration
    public int duration = 0;
    public int cooldown = 0;
    private bool isTimerRunning = false;
    private bool attacking = false;

    public int aura_duration = 5;
    public int debug_counter = 0;
    public int aura_cooldown = 0;   
    public int aura_cooling = 0;
    private bool aura_on = false;
    private void Start()
    {
        StartTimer();
        //make aura invisible
        aura.GetComponent<Renderer>().enabled = false;
        aura_cooldown = rngatk.Next(5, 20);
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

       
            if (atk == 0)
            {   /*
                attacking = true;
                Debug.Log("poopoo go!");
                GameObject projectile1 = Instantiate(poopoo, firepoint.position, firepoint.rotation);
                projectile1.GetComponent<Rigidbody2D>().AddForce(firepoint.up * boss_fireforce, ForceMode2D.Impulse);
                cooldown = 0;
                attacking = false;
                */
            }

            else if ( atk == 1 || aura_on )
            {   
                if(aura_cooldown <= aura_cooling) 
                { 
                    if(attacking == false)
                    {
                        duration = 0;
                    }
                    Debug.Log("aura is here!");
                    if (duration < aura_duration)
                    {   
                        aura_on = true;
                        attacking = true;
                        aura.GetComponent<Renderer>().enabled = true;
                        Debug.Log("aura go!");
                    
                    }
                    else 
                    {   
                        Debug.Log("aura gone!");
                        aura.GetComponent<Renderer>().enabled = false;
                        aura_cooldown = rngatk.Next(5, 20);
                        attacking = false;
                        aura_cooling = 0;
                        aura_on = false;
                        duration = 0;
                    }
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
            aura_cooling++;

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
