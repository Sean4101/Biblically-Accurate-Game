using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStatus : MonoBehaviour
{
    [Header("References")]
    public OphanimLevelBattleManager battleManager;

    public int maxHealth = 100;
    public int CurrentHealth { get; private set; }

    void Start()
    {
        CurrentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;

        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        battleManager.BattleVictory();
    }
}
