using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    public float stayTime = 1f;
    public float explosionDamage = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyExplosion", stayTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Explode()
    {
        Invoke("DestroyExplosion", stayTime);   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Enemy")
        {   
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            collision.SendMessage("TakeDamage", explosionDamage);
            //collision.SendMessage("TakeDamage", 0);
        }
        else if (collision.tag == "HostileProjectile")
        {
            //destroy the projectiles
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Destroy(collision.gameObject);
        }
    }

    void DestroyExplosion()
    {
        Destroy(gameObject);
    }

   
}
