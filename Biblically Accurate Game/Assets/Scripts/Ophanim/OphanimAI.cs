using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum OphanimState
{
    Idle,
    SpearShot,
    PlayerChase,
    BackToCenter,
    DiscoSpin
}

public class OphanimAI : MonoBehaviour
{
    OphanimAttack ophanimAttack;

    public OphanimState state = OphanimState.Idle;

    public int atkType = 0;

    [Header("Cool Downs")]
    public float atkCooldown = 0f;

    [Header("Attack Durations")]
    public float discoSpinDuration = 10f;
    public float spearShotDuration = 10f;

    [Header("Debugging")]
    public int debugCounter = 0;

    private void Awake()
    {
        ophanimAttack = GetComponent<OphanimAttack>();
    }

    private void Start()
    {
        SwitchToState(OphanimState.Idle);
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        UpdateStateMachine();
    }

    void SwitchToState(OphanimState newState)
    {
        switch (state)
        {
            case OphanimState.Idle:
                EndIdle();
                break;
            case OphanimState.SpearShot:
                EndSpearShot();
                break;
            case OphanimState.PlayerChase:
                break;
            case OphanimState.BackToCenter:
                break;
            case OphanimState.DiscoSpin:
                EndDiscoSpin();
                break;
            default:
                break;
        }
        state = newState;
        switch (state)
        {
            case OphanimState.Idle:
                StartIdle();
                break;
            case OphanimState.SpearShot:
                StartSpearShot();
                break;
            case OphanimState.PlayerChase:
                break;
            case OphanimState.BackToCenter:
                break;
            case OphanimState.DiscoSpin:
                StartDiscoSpin();
                break;
            default:
                break;
        }
    }

    void UpdateStateMachine()
    {
        switch (state)
        {
            case OphanimState.Idle:
                UpdateIdle();
                break;
            case OphanimState.SpearShot:
                UpdateSpearShot();
                break;
            case OphanimState.PlayerChase:
                break;
            case OphanimState.BackToCenter:
                break;
            case OphanimState.DiscoSpin:
                UpdateDiscoSpin();
                break;
            default:
                break;
        }
    }

    // Idle State
    float coolingDown = 0;
    void StartIdle()
    {   
        coolingDown = Time.time;
        atkCooldown = UnityEngine.Random.Range(5f, 10f);
        //atkType = UnityEngine.Random.Range(0, 3);
        atkType = 1;
    }

    void UpdateIdle()
    {
        
        if (Time.time - coolingDown > atkCooldown)
        {
            if (atkType == 0)
            {
                SwitchToState(OphanimState.DiscoSpin);
            }
            else if (atkType == 1)
            {
                SwitchToState(OphanimState.SpearShot);
            }
            else if (atkType == 2)
            {
                SwitchToState(OphanimState.PlayerChase);
            }
        }
    }

    void EndIdle()
    {

    }

    // Disco Spin State
    float discoAttackStartTime = 0;

    void StartDiscoSpin()
    {   
        discoAttackStartTime = Time.time;
        ophanimAttack.RayInitialize();
    }

    void UpdateDiscoSpin()
    {
        if (Time.time - discoAttackStartTime > discoSpinDuration)
        {
            SwitchToState(OphanimState.Idle);
        }
    }

    void EndDiscoSpin()
    {   
        ophanimAttack.EndDiscoSpin();
    }

    // Spear Shot State
    float spearAttackStartTime = 0;
    void StartSpearShot()
    {   
        spearAttackStartTime = Time.time;
        ophanimAttack.SpearInitialize();
    }

    void UpdateSpearShot()
    {
        if (Time.time - spearAttackStartTime > spearShotDuration)
        {
            SwitchToState(OphanimState.Idle);
        }
    }

    void EndSpearShot()
    {
       
        ophanimAttack.EndSpear();

    }
}
