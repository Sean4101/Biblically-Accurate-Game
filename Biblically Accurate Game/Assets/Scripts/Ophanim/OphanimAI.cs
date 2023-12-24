using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OphanimAI : MonoBehaviour
{
    OphanimCombat combat;
    OphanimMovement movement;
    BossStatus status;
    DiscoArena discoArena;

    [Header ("Duration")]
    public float wanderDuration = 5f;
    public float chaseDuration = 5f;
    public float orbStreamDuration = 5f;
    public float orbSpiralDuration = 5f;
    public float combo1Duration = 10f;

    [Header("Stats")]
    public int orbSpiralDirectionAmount = 8;
    public int orbShooterAmount = 4;
    

    private void Awake()
    {
        combat = GetComponent<OphanimCombat>();
        movement = GetComponent<OphanimMovement>();
        status = GetComponent<BossStatus>();
        discoArena = FindObjectOfType<DiscoArena>();
    }

    public void EnableAI()
    {
        StartCoroutine(AICoroutine());
        StartCoroutine(ArenaCoroutine());
    }

    public void DisableAI()
    {
        StopAllCoroutines();
    }

    private IEnumerator AICoroutine()
    {
        yield return new WaitForSeconds(1f);
        while (true)
        {
            combat.MinionSpawnShooter();
            yield return new WaitForSeconds(5f);
            combat.ShooterOrbAttack(orbShooterAmount);
            yield return new WaitForSeconds(5f);
            combat.MinionSpawnChaser();
            yield return new WaitForSeconds(5f);
            BulletHellCombo1(combo1Duration);
            yield return new WaitForSeconds(5f);
            movement.Wander(wanderDuration);
            yield return new WaitForSeconds(5f);
            movement.ChasePlayer(chaseDuration);
            yield return new WaitForSeconds(5f);
            combat.OrbStreamAttack(orbStreamDuration);
            yield return new WaitForSeconds(10f);
            combat.OrbSpiralAttack(orbSpiralDuration, orbSpiralDirectionAmount);
            yield return new WaitForSeconds(10f);
            
        }
    }

    private IEnumerator ArenaCoroutine()
    {
        yield return new WaitForSeconds(6f);
        while (true)
        {
            discoArena.RandomActivation(30);
            yield return new WaitForSeconds(5f);
        }
    }

    public void BulletHellCombo1( float duration )
    {
        combat.OrbStreamAttack(duration);
        combat.OrbSpiralAttack(duration, orbSpiralDirectionAmount);
    }
}
