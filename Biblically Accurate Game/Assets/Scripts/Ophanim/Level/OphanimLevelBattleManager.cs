using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OphanimLevelBattleManager : MonoBehaviour
{
    public BossStatus bossStatus;
    public PlayerStatus playerStatus;

    public bool battleComplete = false;
    public bool battleVictorious = false;

    public void StartBattle()
    {

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
        battleComplete = true;
        battleVictorious = true;
    }

    public void BattleDefeat()
    {
        Debug.Log("Battle complete");
        battleComplete = true;
        battleVictorious = false;
    }
}
