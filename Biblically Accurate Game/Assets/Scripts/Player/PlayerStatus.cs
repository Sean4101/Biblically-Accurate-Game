using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    public int MaxHealth = 10;
    public bool Invincible = false;
    public bool RecentlyDamagedInvincible = false;
    public float InvincibilityDuration = 1f;

    float recentlyDamagedTimer = 0f;
    float recentlyDamagedFlashDuration = 0.1f;

    [Header("References")]
    public GameObject invincibleAura;

    public int CurrentHealth { get; private set; }

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        CurrentHealth = MaxHealth;
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
            StartCoroutine(TakeDamageCoroutine());
        }
    }

    public void SetInvincible(bool invincible)
    {
        Invincible = invincible;
        invincibleAura.SetActive(invincible);
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
}
