using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OphanimLevelManager : MonoBehaviour
{
    OphanimLevelIntroManager levelIntro;
    OphanimLevelBattleManager levelBattle;
    OphanimLevelOutroManager levelOutro;

    CameraEffects cameraEffects;
    public PlayerManager playerManager;

    private void Awake()
    {
        levelIntro = GetComponent<OphanimLevelIntroManager>();
        levelBattle = GetComponent<OphanimLevelBattleManager>();
        levelOutro = GetComponent<OphanimLevelOutroManager>();
        cameraEffects = Camera.main.GetComponent<CameraEffects>();
    }

    public void Start()
    {
        StartCoroutine(LevelSequencer());
    }

    private IEnumerator LevelSequencer()
    {
        // Prologue

        playerManager.DisableControl();
        levelIntro.StartIntro();
        yield return new WaitUntil(() => levelIntro.introComplete);

        playerManager.EnableControl();
        levelBattle.StartBattle();
        yield return new WaitUntil(() => levelBattle.battleComplete);

        playerManager.DisableControl();
        if (levelBattle.battleVictorious)
        {
            levelOutro.StartVictoryOutro();
        }
        else
        {   
            cameraEffects.ZoomInOnProtag();
            levelOutro.StartDefeatOutro();
        }
    }
}
