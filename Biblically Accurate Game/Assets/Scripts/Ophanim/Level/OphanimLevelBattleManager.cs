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
        if (bossStatus.CurrentHealth <= 0 && !battleComplete)
        {
            BattleVictory();
        }
        else if (playerStatus.CurrentHealth <= 0 && !battleComplete)
        {
            BattleDefeat();
        }
    }

    public void BattleVictory()
    {
        bossAI.DisableAI();
        battleComplete = true;
        battleVictorious = true;
    }

    public void BattleDefeat()
    {
        bossAI.DisableAI();
        battleComplete = true;
        battleVictorious = false;
    }
}
