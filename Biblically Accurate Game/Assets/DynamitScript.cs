using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamitScript : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("References")]
    public float timeToExplode = 1f;
    public ExplosionScript explosionScript;
    void Awake()
    {
         explosionScript = GetComponent<ExplosionScript>();
    }
    void Start()
    {
        Invoke("DynamiteExplode", timeToExplode); //2f is the time before the bullet is destroyed
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    void DynamiteExplode()
    {
         Destroy(gameObject);

        if (explosionScript != null)
        {
            explosionScript.Explode();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
       

        if(explosionScript != null)
        {
            if ( collision.tag != "HostileProjectile")
                {
                    DynamiteExplode();
                    explosionScript.Explode();
                }

                if (collision.tag == "Enemy")
                {
                    collision.SendMessage("TakeDamage", 0);
                    GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                }
        }
        

    }
}
