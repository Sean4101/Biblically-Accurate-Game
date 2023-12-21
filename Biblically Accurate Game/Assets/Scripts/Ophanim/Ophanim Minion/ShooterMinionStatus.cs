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

    public int ShooterMinionCurrentHealth { get; private set; }
    void Start()
    {
        ShooterMinionCurrentHealth = maxShooterMinionHealth;
    }

    public void TakeDamage(int damage)
    {
        ShooterMinionCurrentHealth -= damage;

        if (ShooterMinionCurrentHealth <= 0)
        {
            Die();
        }
    }
    
    void Die()
    {
        int dropDynamite = Random.Range(0, 7);
        if (dropDynamite == 2)
        {
            Instantiate(dynamiteDrop, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
