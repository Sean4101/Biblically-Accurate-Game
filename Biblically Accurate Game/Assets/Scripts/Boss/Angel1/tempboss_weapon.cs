//contains code template, DO NOT DELETE
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


public class tempboss_weapon : MonoBehaviour
{
    public GameObject poopoo;

    //public Transform firePoint;
    public GameObject player;
    public Transform bossPoint;
    public Transform angel1;
    public float boss_fireforce = 20f;
    public rayScript rayStuff;

    public float speed;

    public float rotationModifier;

    System.Random rngatk = new System.Random((int)DateTime.Now.Ticks);
    public GameObject aura;
    public GameObject ray;
    public Rigidbody2D rayrb;
    public Rigidbody2D aurarb;

    [Header("General Info")]
    public int atk = 0;
    private int timer = 0; // Initial timer duration
    public int duration = 0;
    public int cooldown = 0;
    private bool isTimerRunning = false;
    private bool attacking = false;
    
    [Header("Ray Stats")]
    private int rayAmount = 0;
    private bool rayCreated = false;
    public float rayMaxspeed = 50f;
    public float rayMinspeed = 40f;

    [Header("Aura Stats")]
    public int auraDuration = 10;
    public int auraCooldown = 0;
    public int auraCooling = 0;
    private bool auraOn = false;
    //////////////////////////////
    
    [Header("Debugging")]
    public int debugCounter = 0;
    private void Start()
    {
        initialSetup();
        initialRandomized();
    }
    private void Update()
    {
        MakeFollow(aura, aurarb); //not neccesary
        MakeFollow(ray, rayrb); //not neccesary
    }
    private void FixedUpdate()
    {
       /*
        //points at player
        if (player != null)
        {
            Vector3 vectorToTarget = player.transform.position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - rotationModifier;
            Quaternion q = Quaternion.AngleAxis(angle - 80, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);

            //firepoint points as the same direction as rotation
            bossPoint.rotation = Quaternion.Slerp(bossPoint.rotation, q, Time.deltaTime * speed);
        }
       */
        

        if (atk == 0)
        {
              /*
                attacking = true;
                Debug.Log("poopoo go!");
                GameObject projectile1 = Instantiate(poopoo, firepoint.position, firepoint.rotation);
                projectile1.GetComponent<Rigidbody2D>().AddForce(firepoint.up * boss_fireforce, ForceMode2D.Impulse);
                cooldown = 0;
                attacking = false;
                */
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
                
                TimerTick();
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

    void MakeFollow(GameObject item, Rigidbody2D itemrb)
    {
        Vector2 itemPos = new Vector2(angel1.position.x, angel1.position.y);
        gameObject.transform.position = itemPos;
        //make rb follow protag
        itemrb.MovePosition(itemPos);
    }

    void TimerTick()
    {   
        auraCooling++;
        //Debug.Log("timer ticked");

        if (atk == 1 || auraOn)
        {
            if (auraCooldown <= auraCooling)
            {
                DiscoRay();
            }
        }
        
    }

    void DiscoRay()
    {
        if (attacking == false)
        {
            duration = 0;
        }

        //Debug.Log("aura is here!");

        if (duration < auraDuration)
        {
            auraOn = true;
            attacking = true;
            aura.GetComponent<Renderer>().enabled = true;
            //Debug.Log("aura go!");
            //print ray amount
            //Debug.Log("ray amount: " + rayAmount);
            if (!rayCreated)
            {
                for (int i = 0; i < rayAmount; i++)
                {   
                    float randomtorque = UnityEngine.Random.Range(rayMinspeed, rayMaxspeed);
                    int direction = UnityEngine.Random.Range(0,2);
                    Color randomColor = new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f));
                    Quaternion randomRotation = Quaternion.Euler(0f, 0f, UnityEngine.Random.Range(0f, 360f));
                    //print random rotation
                    Debug.Log("random rotation: " + randomRotation.eulerAngles.z);

                    // Instantiate GameObject with random rotation
                    GameObject holyLight = Instantiate(ray, angel1.position, randomRotation);
                    holyLight.GetComponent<SpriteRenderer>().color = randomColor;
                    //makes ray rotate in random direction
                    
                    
                    if( direction == 0)
                    {
                        holyLight.GetComponent<Rigidbody2D>().AddTorque(randomtorque*(-1));
                    }
                    else if( direction == 1 )
                    {
                        holyLight.GetComponent<Rigidbody2D>().AddTorque(randomtorque);
                    }

                }
                rayCreated = true;
            }
        }
        else
        {
            //Debug.Log("aura gone!");
            aura.GetComponent<Renderer>().enabled = false;
            auraCooldown = rngatk.Next(5, 20);
            attacking = false;
            auraCooling = 0;
            auraOn = false;
            duration = 0;
            atk = rngatk.Next(0, 3);
            cooldown = rngatk.Next(5, 8);
            rayCreated = false;

            
        }

    }


    void initialRandomized()
    {
        auraCooldown = rngatk.Next(5, 20);
        rayAmount = UnityEngine.Random.Range(10, 18);
        atk = rngatk.Next(0, 3);
        cooldown = rngatk.Next(5, 8);
    }

    private void initialSetup()
    {
        auraDuration = 10;
        StartTimer();
        aura.GetComponent<Renderer>().enabled = false;


    }


}