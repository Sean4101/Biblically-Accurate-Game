using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStatus : MonoBehaviour
{
    [Header("References")]
    public OphanimLevelBattleManager battleManager;

    public int maxHealth = 100;
    public int healAmount = 4;
    public float flashDuration = 0.1f;
    private SpriteRenderer spriteRenderer;
    public Color flashColor = new Color(1f, 0f, 0f, 1f);



    public int CurrentHealth { get; private set; }

    void Start()
    {
        CurrentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        StartCoroutine(FlashCoroutine());

        //flash red for 0.1 seconds


        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal()
    {
        CurrentHealth += healAmount;
        if (CurrentHealth > maxHealth)
        {
            CurrentHealth = maxHealth;
        }
    }

    private IEnumerator FlashCoroutine()
    {
        Color originalColor = spriteRenderer.color;

        // Change to flashColor
        spriteRenderer.color = flashColor;

        // Wait for a short duration
        yield return new WaitForSeconds(flashDuration);

        // Change back to the original color
        spriteRenderer.color = originalColor;
    }
    void Die()
    {   
        //set velocity to 0
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        battleManager.BattleVictory();
    }
}
