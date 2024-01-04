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

    public BackGroundMusicController BGM;
    public BossBGMPlayer BossBGM;

    public void StartBattle()
    {
        bossAI.EnableAI();
        BGM.ChangeToBossBGM();
        BossBGM.ChangeBack();
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
        BGM.ChangeBack();
        BossBGM.ChangeToBGM();
        battleComplete = true;
        battleVictorious = true;
    }

    public void BattleDefeat()
    {
        bossAI.DisableAI();
        BGM.ChangeBack();
        BossBGM.ChangeToBGM();
        battleComplete = true;
        battleVictorious = false;
    }


}
