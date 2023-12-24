using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterMinionStatus : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("References")]
    public GameObject dynamiteDrop;
    public GameObject healthDrop;

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
        int rng = Random.Range(0, 4);

        if (rng == 0)
        {
            dropDynamite();
        }
        else if (rng == 1)
        {
            dropHealth();
        }

        Destroy(gameObject);
    }

    void dropHealth()
    {
        int dropHealth = 2;//Random.Range(0, 5);
        if (dropHealth == 2)
        {
            Instantiate(healthDrop, transform.position, Quaternion.identity);
        }
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
