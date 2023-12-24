using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserMinionStatus : MonoBehaviour
{
    [Header ("References")]
    public GameObject dynamiteDrop;
    public GameObject healthDrop;

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

    void dropDynamite()
    {
        int dropDynamite = 2;//Random.Range(0, 5);
        if (dropDynamite == 2)
        {
            Instantiate(dynamiteDrop, transform.position, Quaternion.identity);
        }
    }

    void dropHealth()
    {
        int dropHealth = 2;//Random.Range(0, 5);
        if (dropHealth == 2)
        {
            Instantiate(healthDrop, transform.position, Quaternion.identity);
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
