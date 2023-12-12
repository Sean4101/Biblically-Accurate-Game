using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OphanimLevelBattleManager : MonoBehaviour
{
    public BossStatus bossStatus;
    public OphanimAI bossAI;
    public PlayerStatus playerStatus;

    public bool battleComplete = false;
    public bool battleVictorious = false;

    public void StartBattle()
    {
        bossAI.EnableAI();
    }

    private void Update()
    {
        if (bossStatus.CurrentHealth <= 0)
        {
            BattleVictory();
        }
        else if (playerStatus.CurrentHealth <= 0)
        {
            BattleDefeat();
        }
    }

    public void BattleVictory()
    {
        Debug.Log("Battle complete");
        bossAI.DisableAI();
        battleComplete = true;
        battleVictorious = true;
    }

    public void BattleDefeat()
    {
        Debug.Log("Battle complete");
        bossAI.DisableAI();
        battleComplete = true;
        battleVictorious = false;
    }
}
