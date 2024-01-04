using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    [Header("Stats")]
    public int MaxHealth = 10;
    public bool Invincible = false;
    public bool RecentlyDamagedInvincible = false;
    public float InvincibilityDuration = 1f;

    [SerializeField] private float knockbackForce = 250f;

    float recentlyDamagedTimer = 0f;
    float recentlyDamagedFlashDuration = 0.1f;

    [Header("References")]
    CameraEffects cameraEffects;

    public int CurrentHealth { get; private set; }

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        CurrentHealth = MaxHealth;
        cameraEffects = Camera.main.GetComponent<CameraEffects>();

    }
    public void playerHeal( int healAmount)
        {
            if (CurrentHealth < MaxHealth)
            {
                CurrentHealth += healAmount;
            }
            else
            {
                CurrentHealth = MaxHealth;
            }
        }
    public void TakeDamage(int damage)
    {   
        
        if (Invincible || RecentlyDamagedInvincible)
            return;
        CurrentHealth -= damage;
       
        if (CurrentHealth <= 0)
        {
            Die();
        }
        else
        {   
            cameraEffects.Shake(0.1f);
            StartCoroutine(TakeDamageCoroutine());
        }
    }

    public void SetInvincible(bool invincible)
    {
        Invincible = invincible;
    }

    public IEnumerator TakeDamageCoroutine()
    {
        RecentlyDamagedInvincible = true;
        recentlyDamagedTimer = Time.time;
        while (Time.time - recentlyDamagedTimer < InvincibilityDuration)
        {   
            spriteRenderer.color = new Color(.7f, 0f, 0f, 1f);
            yield return new WaitForSeconds(recentlyDamagedFlashDuration);
            spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(recentlyDamagedFlashDuration);
        }
        RecentlyDamagedInvincible = false;
    }

    void Die()
    {
        
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( !Invincible  && collision.CompareTag("Enemy"))
        {   
            //knockback
            Vector2 knockbackDirection = (transform.position - collision.transform.position).normalized;
            if (collision.name.Contains("Disco Aura"))
            {
                GetComponent<Rigidbody2D>().AddForce(knockbackDirection * knockbackForce * 10);
            }
            else
            {
                GetComponent<Rigidbody2D>().AddForce(knockbackDirection * knockbackForce);
            }

        }

        
        if (collision.CompareTag("HostileProjectile") && !collision.name.Contains("ShooterOrb") && (!Invincible))
        {
           
                Destroy(collision.gameObject);

        }
    }
}
