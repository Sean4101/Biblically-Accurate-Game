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
    public GameObject BossBGMControll;

    public void StartBattle()
    {
        bossAI.EnableAI();
        BGM.ChangeToBossBGM();
        BossBGMControll.GetComponent<BossBGMPlayer>().ChangeBack();
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
        BossBGMControll.GetComponent<BossBGMPlayer>().ChangeToBGM();
        battleComplete = true;
        battleVictorious = true;
    }

    public void BattleDefeat()
    {
        bossAI.DisableAI();
        BGM.ChangeBack();
        BossBGMControll.GetComponent<BossBGMPlayer>().ChangeToBGM();
        battleComplete = true;
        battleVictorious = false;
    }


}
