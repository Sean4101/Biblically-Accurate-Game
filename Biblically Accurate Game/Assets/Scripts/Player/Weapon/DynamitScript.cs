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
    void Awake()
    {
         
    }
    void Start()
    {
        Invoke("DynamiteExplode", timeToExplode); //2f is the time before the bullet is destroyed
        cameraEffects = Camera.main.GetComponent<CameraEffects>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    void DynamiteExplode()
    {   
        cameraEffects.Shake(0.7f);
        GameObject explosionRadius = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.tag == "HostileProjectile" && collision.tag != "FriendlyProjectile" )
            {
                DynamiteExplode();
                //debug, shows the name of the object that the bullet collided with
                Debug.Log("Dynamite hit " + collision.name);
            }

        else if (collision.tag == "Enemy")
            {   
                //collision.SendMessage("TakeDamage", 0); dynmaite itself should not deal damage
                Debug.Log("Enemy hit by dynamite");
                DynamiteExplode();

                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }

    }
}
