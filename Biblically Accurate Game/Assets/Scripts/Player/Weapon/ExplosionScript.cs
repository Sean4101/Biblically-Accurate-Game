using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    public float stayTime = 1f;
    public float explosionDamage = 5f;
    [SerializeField] private int skillChargeAmount = 5;
    PlayerCombat playerCombat;

    [Header("Reference")]
    public AudioSource explosionAudioSource;
    public AudioClip explosionAudioClip;

    // Start is called before the first frame update
    void Start()
    {
        PlayExplosion();
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
        explosionAudioSource.transform.parent = null;

        Destroy(gameObject);
    }

    public void PlayExplosion()
    {
        explosionAudioSource.volume = 0.5f;
        explosionAudioSource.pitch = 1.49f;
        explosionAudioSource.time = 0f;
        explosionAudioSource.Play();
    }
}
