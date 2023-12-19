using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterMinionStatus : MonoBehaviour
{
    // Start is called before the first frame update
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
        Destroy(gameObject);
    }
}
