using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    public float stayTime = 1f;
    public float explosionDamage = 5f;
    [SerializeField] private int skillChargeAmount = 5;
    PlayerCombat playerCombat;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyExplosion", stayTime);
        playerCombat = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombat>();

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
            playerCombat.ChargeNormalSkill(skillChargeAmount);
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
