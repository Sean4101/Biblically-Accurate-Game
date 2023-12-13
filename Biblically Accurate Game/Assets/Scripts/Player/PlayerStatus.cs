using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public int MaxHealth = 10;
    public bool Invincible = false;

    [Header("References")]
    public GameObject invincibleAura;

    public int CurrentHealth { get; private set; }

    void Awake()
    {
        CurrentHealth = MaxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (Invincible)
            return;
        CurrentHealth -= damage;
        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    public void SetInvincible(bool invincible)
    {
        Invincible = invincible;
        invincibleAura.SetActive(invincible);
    }

    void Die()
    {

    }
}
