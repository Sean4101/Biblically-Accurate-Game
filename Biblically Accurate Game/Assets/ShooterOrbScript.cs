using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterOrbScript : MonoBehaviour
{
    public int damage = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyShooterOrb", 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DestroyShooterOrb()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerStatus>().TakeDamage(damage);
            //Destroy(gameObject);
        }
        if (collision.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }

}
