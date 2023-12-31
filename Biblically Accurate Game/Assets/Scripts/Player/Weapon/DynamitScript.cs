using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamitScript : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("References")]
    public float timeToExplode = 1f;
    public GameObject explosionPrefab;
    CameraEffects cameraEffects;
    public ExplosionScript explosionScript;

    void Start()
    {
        Invoke("DynamiteExplode", timeToExplode); //2f is the time before the bullet is destroyed
        cameraEffects = Camera.main.GetComponent<CameraEffects>();
    }

    void DynamiteExplode()
    {   
        cameraEffects.Shake(0.1f);
        GameObject explosionRadius = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        explosionScript.explosionDamage = 5;
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
            
        if (collision.tag == "Enemy")
            {   
                //collision.SendMessage("TakeDamage", 0); dynmaite itself should not deal damage
                Debug.Log("Enemy hit by dynamite");
                DynamiteExplode();
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
        if (collision.tag == "Obstacle")
        {
            DynamiteExplode();
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }


    }
}
