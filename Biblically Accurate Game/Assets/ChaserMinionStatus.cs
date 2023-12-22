using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserMinionStatus : MonoBehaviour
{
    [Header ("References")]
    public GameObject dynamiteDrop;

    [Header("Stats")]
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
        int dropDynamite = 2;//Random.Range(0, 5);
        if(dropDynamite == 2)
        {
            Instantiate(dynamiteDrop, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
