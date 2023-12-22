using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserMinionStatus : MonoBehaviour
{
    [Header ("References")]
    public GameObject dynamiteDrop;

    [Header("Renderer stats")]
    public float flashDuration = 0.1f;
    private SpriteRenderer spriteRenderer;
    public Color flashColor = new Color(1f, 0f, 0f, 1f);

    [Header("Stats")]
    public int maxChaserMinionHealth = 20;
    public int ChaserMinionCurrentHealth { get; private set; }
    void Start()
    {
        ChaserMinionCurrentHealth = maxChaserMinionHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    public void TakeDamage(int damage)
    {
        ChaserMinionCurrentHealth -= damage;
        StartCoroutine(FlashCoroutine());

        if (ChaserMinionCurrentHealth <= 0)
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
