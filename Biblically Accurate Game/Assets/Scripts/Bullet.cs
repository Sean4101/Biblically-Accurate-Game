using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Start()
    {
        Invoke("DestroyBullet", 3f); //2f is the time before the bullet is destroyed
    }

    // Update is called once per frame
    void Update()
    {

    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if(collision.tag == "Enemy")
        {
            collision.SendMessage("TakeDamage", 0);
        }

        DestroyBullet();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log("we are still colliding");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("we are no longer colliding");
    }

}
