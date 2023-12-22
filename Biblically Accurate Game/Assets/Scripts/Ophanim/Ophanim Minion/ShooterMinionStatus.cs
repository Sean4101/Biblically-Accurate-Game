using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterMinionStatus : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("References")]
    public GameObject dynamiteDrop;

    [Header("Stats")]
    public int maxShooterMinionHealth = 10;

    [Header("Renderer stats")]
    public float flashDuration = 0.1f;
    private SpriteRenderer spriteRenderer;
    public Color flashColor = new Color(1f, 0f, 0f, 1f);

    public int ShooterMinionCurrentHealth { get; private set; }
    void Start()
    {
        ShooterMinionCurrentHealth = maxShooterMinionHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    public void TakeDamage(int damage)
    {
        ShooterMinionCurrentHealth -= damage;
        StartCoroutine(FlashCoroutine());

        if (ShooterMinionCurrentHealth <= 0)
        {
            Die();
        }
    }
    
    void Die()
    {
        dropDynamite();
        Destroy(gameObject);
    }

    void dropDynamite()
    {
        int dropDynamite = 2;//Random.Range(0, 5);
        if (dropDynamite == 2)
        {
            Instantiate(dynamiteDrop, transform.position, Quaternion.identity);
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


}
