using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimensionRiftScript : MonoBehaviour
{

    [Header("References")]
    public float timeToStartSuck = 1.5f;
    public float suckDamage = 2f;
    bool isSucking = false;
    public float pullForce = 100f;
    public float overlapCircleRadius = 100f;
    public float suckDuration = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("StartSuck", timeToStartSuck); 
        Invoke("DestroyRift", 5f);  
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartSuck()
    {
        isSucking = true;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        StartCoroutine(Suck( suckDuration ));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "HostileProjectile" && isSucking)
        {   
            Debug.Log("Projectile sucked");
            //destroy the projectile
            Destroy(collision.gameObject);
        }
        if (collision.tag == "Enemy" && isSucking)
        {
            // enemy takes damage every 0.5 seconds

            StartCoroutine(DamageOverTime(collision.gameObject));

        }

    }

    private IEnumerator DamageOverTime(GameObject enemy)
    {
        while (isSucking)
        {
            // Apply damage to the enemy
            enemy.SendMessage("TakeDamage", suckDamage);

            // Wait for 0.5 seconds before dealing damage again
            yield return new WaitForSeconds(0.5f);
        }
    }

    /*modify the following code to fit the enumator*/
    /*
       //pull enemies and hostileprojectiels towards the rift
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, overlapCircleRadius);
        foreach (Collider2D collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Debug.Log("Enemy pulled");
                Vector2 direction = transform.position - collider.transform.position;
                collider.GetComponent<Rigidbody2D>().AddForce(direction.normalized * pullForce);
            }
            else if (collider.tag == "HostileProjectile")
            {
                Debug.Log("Projectile pulled");
                Vector2 direction = transform.position - collider.transform.position;
                collider.GetComponent<Rigidbody2D>().AddForce(direction.normalized * pullForce);
            }
        }*/

    private IEnumerator Suck(float duration)
    {
        float timeElapsed = 0f;
        while (timeElapsed < duration)
        {
            //pull enemies and hostileprojectiels towards the rift
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, overlapCircleRadius);
            foreach (Collider2D collider in colliders)
            {
                if (collider.tag == "Enemy")
                {
                    Debug.Log("Enemy pulled");
                    Vector2 direction = transform.position - collider.transform.position;
                    collider.GetComponent<Rigidbody2D>().AddForce(direction.normalized * pullForce);
                }
                else if (collider.tag == "HostileProjectile")
                {
                    Debug.Log("Projectile pulled");
                    Vector2 direction = transform.position - collider.transform.position;
                    collider.GetComponent<Rigidbody2D>().AddForce(direction.normalized * pullForce);
                }
            }
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        isSucking = false;
    }
    void DestroyRift()
    {
        Destroy(gameObject);
    }

}
