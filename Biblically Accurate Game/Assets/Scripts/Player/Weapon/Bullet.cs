using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    int damage;

    public GameObject bulletImpactEffect;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        Invoke(nameof(DestroyBullet), 3f);
    }

    public void Fire(int _damage, float force)
    {
        rb.AddForce(transform.right * force, ForceMode2D.Impulse);
        damage = _damage;
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if(collision.CompareTag("Enemy"))
        {
            collision.SendMessage("TakeDamage", damage);
            Instantiate(bulletImpactEffect, transform.position, Quaternion.identity);
            DestroyBullet();
        }
    }
}
