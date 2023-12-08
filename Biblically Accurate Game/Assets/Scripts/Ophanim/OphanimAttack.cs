using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OphanimAttack : MonoBehaviour
{
    public GameObject aura;
    public GameObject ray;
    public Rigidbody2D rayrb;
    public Rigidbody2D aurarb;
    public GameObject poopoo;
    public GameObject spear;

    //public Transform firePoint;
    public GameObject player;
    public Transform bossPoint;
    public Transform angel1;
    
    public float boss_fireforce = 20f;
    //public rayScript rayStuff;

    public float speed;
    public bool switchState = false;
    public float rotationModifier;




    List<Transform> rays = new List<Transform>();
    List<Transform> spears = new List<Transform>();

    [Header("Spear Stats")]
    public int spearAmount = 0;
    public float spearEmergeY = 1f;
    public float spearEmergeTopY = 0.5f;
    public float spearEmergeSpeed = 6f;
    public float spearSpeed = 10f;
    public float initialSpearTransparency = 0f;
    public float transparencyAddSensitivity = 0.01f;
    public float spearRotationSpeed = 10f;
    public float spearAimTime = 2.5f;
    public float spearEmergeSpinSpeed = 780f;
    public float spear1FromBossX = 0.2f;
    public float spear2FromBossX = 0.5f;
    public float spear3FromBossX = 0.2f;
    public float spear4FromBossX = 0.5f;
    public float spearEmergeTime = 1.5f;
    private bool spearOn = false;

    [Header("Ray Stats")]
    private int rayAmount = 0;
    public float rayMaxspeed = 5f;
    public float rayMinspeed = 4f;

    [Header("Aura Stats")]
    public int auraCooldown = 0;
    public int auraAttacking = 0;
    private bool auraOn = false;

    private void Start()
    {
        Renderer auraRenderer = aura.GetComponent<Renderer>();
        auraRenderer.enabled = false;
    }
    private void Update()
    {
        if (auraOn)
        {
            DiscoSpinAttcking();
        }

        if (spearOn)
        {   
            spearAttacking();
        }
    }

    //Disco spin attacks
    public void RayInitialize()
    {
        Renderer auraRenderer = aura.GetComponent<Renderer>();
        auraOn = true;
        //make disco ball visible
        auraRenderer.enabled = true;

        rayAmount = Random.Range(10, 18);

        for (int i = 0; i < rayAmount; i++)
        {   

            Color randomColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            Quaternion randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
            // Instantiate GameObject with random rotation
            GameObject holyLight = Instantiate(ray, angel1.position, randomRotation);
            SpriteRenderer holyLightRenderer = holyLight.GetComponent<SpriteRenderer>();

            rays.Add(holyLight.transform);

            holyLightRenderer.color = randomColor;

            float randomtorque = Random.Range(rayMinspeed, rayMaxspeed);
            int direction = Random.Range(0, 2);

            if (direction == 0)
            {   
                Rigidbody2D rayRb = rays[i].GetComponent<Rigidbody2D>();
                rayRb.AddTorque(randomtorque * (-1));
            }
            else if (direction == 1)
            {
                Rigidbody2D rayRb = rays[i].GetComponent<Rigidbody2D>();

                rayRb.AddTorque(randomtorque);
            }

        }
    }


    void DiscoSpinAttcking()
    {
       
    }

    public void EndDiscoSpin()
    {   
        Renderer auraRenderer = aura.GetComponent<Renderer>();
        auraOn = false;
        auraRenderer.enabled = false;
        for (int i = 0; i < rays.Count; i++)
        {
            Destroy(rays[i].gameObject);
        }
        auraRenderer.enabled = false;
        rays.Clear();

    }

    //spear attacks
    float aimingTime = 0f;
    public void SpearInitialize()
    {   
        Debug.Log("spear initialized");
        spearOn = true;
        spearAmount = 4;
        
        
        for (int i = 0; i < spearAmount; i++)
        {   
            int direction = Random.Range(0, 2);
            Quaternion randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));

            if (i == 0)
            {
                GameObject holySpear = Instantiate(spear, new Vector3(bossPoint.position.x + spear1FromBossX, bossPoint.position.y - spearEmergeY, bossPoint.position.z), randomRotation);
                spears.Add(holySpear.transform);
            }
            else if (i == 1)
            {
                GameObject holySpear = Instantiate(spear, new Vector3(bossPoint.position.x + spear2FromBossX, bossPoint.position.y - spearEmergeY, bossPoint.position.z), randomRotation);
                spears.Add(holySpear.transform);
            }
            else if(i == 2)
            {
                GameObject holySpear = Instantiate(spear, new Vector3(bossPoint.position.x - spear3FromBossX, bossPoint.position.y - spearEmergeY, bossPoint.position.z), randomRotation);
                spears.Add(holySpear.transform);
            }
            else if(i == 3) 
            {
                GameObject holySpear = Instantiate(spear, new Vector3(bossPoint.position.x - spear4FromBossX, bossPoint.position.y - spearEmergeY, bossPoint.position.z), randomRotation);
                spears.Add(holySpear.transform);
            }
 
            Rigidbody2D spearsRb = spears[i].GetComponent<Rigidbody2D>();

            //makes soear spin while emerging
            //emergeTime = Time.time;
            spearsRb.AddTorque(spearEmergeSpinSpeed);
            spearsRb.velocity = new Vector2(0f, spearEmergeSpeed);
            aimingTime = Time.time;
        }
    }

    public void spearAttacking()
    {
       
        bool spearStop = false;

        for (int i = 0; i < spearAmount; i++)
        {
            if (spears[i] != null)
            {
                Rigidbody2D spearsRb = spears[i].GetComponent<Rigidbody2D>();
                if (spears[i] != null && spears[i].position.y > bossPoint.position.y + spearEmergeTopY)
                {
                    spearsRb.velocity = new Vector2(0f, 0f);
                    spearsRb.angularVelocity = 0f;
                    spearStop = true;
                }
            }

        }

        if (spearStop)
        {
            foreach (Transform spear in spears)
            {
                if (spear != null)
                {
                    //makes spear aims at player
                    spear.transform.up = player.transform.position - spear.transform.position;

                    //makes spear move towards player after 2.5 seconds

                    if (Time.time - aimingTime > spearAimTime)
                    {
                        Rigidbody2D spearRb = spear.GetComponent<Rigidbody2D>();
                        spearRb.GetComponent<Rigidbody2D>().velocity = spear.transform.up * spearSpeed;

                    }
                }
            }
        }
       
    }

    public void EndSpear()
    {   
        spearOn = false;
        foreach (Transform spear in spears)
        {
            if (spear != null)
            Destroy(spear.gameObject);
        }
        spears.Clear();
    }

    
    



}
