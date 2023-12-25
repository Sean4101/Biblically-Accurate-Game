using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    public int damage;
    public bool skillActivated;
    [SerializeField] private int skillChargeAmount = 1;

    public GameObject bulletImpactEffect;
    PlayerCombat playerCombat;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        Invoke(nameof(DestroyBullet), 3f);
        playerCombat = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombat>();
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
            playerCombat.ChargeSkill(skillChargeAmount);
            collision.SendMessage("TakeDamage", damage);
            Instantiate(bulletImpactEffect, transform.position, Quaternion.identity);
            DestroyBullet();
        }

        else if (collision.CompareTag("HostileProjectile") && skillActivated)
        {            
            Instantiate(bulletImpactEffect, transform.position, Quaternion.identity);
            //destroy the projectiles
            Destroy(collision.gameObject);
        }
       
    }
}
