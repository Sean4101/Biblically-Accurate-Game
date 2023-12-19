using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserMinionStatus : MonoBehaviour
{
    public int maxChaserMinionHealth = 20;
    public int ChaserMinionCurrentHealth { get; private set; }
    void Start()
    {
        ChaserMinionCurrentHealth = maxChaserMinionHealth;
    }

    public void TakeDamage(int damage)
    {
        ChaserMinionCurrentHealth -= damage;

        if (ChaserMinionCurrentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
