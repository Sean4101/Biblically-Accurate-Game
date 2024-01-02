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
    public float ultraComboDuration = 10f;
    public float regularWaitDuration = 5f;

    [Header("Stats")]
    public int orbSpiralDirectionAmount = 8;
    public int orbShooterAmount = 4;
    public int padAvailableCount = 15;
  
    

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
            movement.ChasePlayer(chaseDuration);
            yield return new WaitForSeconds(regularWaitDuration);
            randomShit();
            yield return new WaitForSeconds(regularWaitDuration);
            randomShit();
            yield return new WaitForSeconds(regularWaitDuration);
            randomShit();
            yield return new WaitForSeconds(regularWaitDuration);
            randomShit();
            yield return new WaitForSeconds(regularWaitDuration);
            movement.Wander(wanderDuration);
            yield return new WaitForSeconds(regularWaitDuration);
            randomShit();
            yield return new WaitForSeconds(regularWaitDuration);
            randomShit();
            yield return new WaitForSeconds(regularWaitDuration);
            movement.Wander(wanderDuration);
            yield return new WaitForSeconds(regularWaitDuration);
            combat.OrbStreamAttack(orbStreamDuration);
            yield return new WaitForSeconds(regularWaitDuration);
            combat.OrbSpiralAttack(orbSpiralDuration, orbSpiralDirectionAmount);
            yield return new WaitForSeconds(regularWaitDuration);
            movementAttack();
            yield return new WaitForSeconds(regularWaitDuration);
            combat.MinionSpawnShooter();
            yield return new WaitForSeconds(regularWaitDuration);
            movement.Wander(wanderDuration);
            yield return new WaitForSeconds(regularWaitDuration);
            orbShooterAmount = 4;
            combat.ShooterOrbAttack(orbShooterAmount);
            yield return new WaitForSeconds(regularWaitDuration);
            movementAttack();
            yield return new WaitForSeconds(regularWaitDuration);
            combat.MinionSpawnChaser();
            yield return new WaitForSeconds(regularWaitDuration);
            BulletHellCombo1(combo1Duration);
            yield return new WaitForSeconds(regularWaitDuration);
            movement.Wander(wanderDuration);
            yield return new WaitForSeconds(regularWaitDuration);
            combat.MinionSpawnShooter();
            yield return new WaitForSeconds(regularWaitDuration);
            movement.ChasePlayer(chaseDuration);
            yield return new WaitForSeconds(regularWaitDuration);
            randomShit();
            yield return new WaitForSeconds(regularWaitDuration);
            randomShit();
            yield return new WaitForSeconds(regularWaitDuration);
            combat.DiscoAuraAttack();
            yield return new WaitForSeconds(regularWaitDuration + 2 );
            movementAttack();
            yield return new WaitForSeconds(regularWaitDuration);
            UltraBulletHellCombo(ultraComboDuration);
            yield return new WaitForSeconds(1f);
            randomShit();
            yield return new WaitForSeconds(regularWaitDuration);
            randomShit();
            yield return new WaitForSeconds(regularWaitDuration);
            combat.MinionSpawnChaser();
            yield return new WaitForSeconds(1f);
            combat.MinionSpawnChaser();
            yield return new WaitForSeconds(1f);
            movement.Wander(wanderDuration);
            yield return new WaitForSeconds(regularWaitDuration);
            combat.MinionSpawnShooter();
            yield return new WaitForSeconds(regularWaitDuration);
            combat.MinionSpawnChaser();
            yield return new WaitForSeconds(1f);
            combat.OrbStreamAttack(orbStreamDuration);
            yield return new WaitForSeconds(regularWaitDuration);
            movementAttack();
            yield return new WaitForSeconds(regularWaitDuration);
            combat.OrbSpiralAttack(orbSpiralDuration, orbSpiralDirectionAmount);
            yield return new WaitForSeconds(regularWaitDuration);
            movement.Wander(wanderDuration);
            yield return new WaitForSeconds(regularWaitDuration);
            discoAuraCombo();
            yield return new WaitForSeconds(regularWaitDuration);
            combat.OrbStreamAttack(orbStreamDuration);
            yield return new WaitForSeconds(regularWaitDuration);
            randomShit();
            yield return new WaitForSeconds(regularWaitDuration);
            randomShit();
            yield return new WaitForSeconds(regularWaitDuration);
            combat.OrbSpiralAttack(orbSpiralDuration, orbSpiralDirectionAmount);
            yield return new WaitForSeconds(regularWaitDuration);
            movement.ChasePlayer(wanderDuration);
            yield return new WaitForSeconds(regularWaitDuration);
            combat.OrbSpiralAttack(orbSpiralDuration, orbSpiralDirectionAmount);
            yield return new WaitForSeconds(regularWaitDuration);
            combat.DiscoAuraAttack();
            movement.ChasePlayer(chaseDuration - 2);


        }
    }

    private IEnumerator ArenaCoroutine()
    {
        yield return new WaitForSeconds(6f);
        while (true)
        {
            discoArena.RandomActivation(padAvailableCount);
            yield return new WaitForSeconds(5f);
        }
    }

    public void BulletHellCombo1( float duration )
    {
        combat.OrbStreamAttack(duration);
        combat.OrbSpiralAttack(duration, orbSpiralDirectionAmount);
    }

    public void UltraBulletHellCombo(float duration)
    {
        combat.OrbStreamAttack(duration);
        combat.OrbSpiralAttack(duration, orbSpiralDirectionAmount);
        orbShooterAmount = 7;
        combat.ShooterOrbAttack(orbShooterAmount);
    }

    public void movementAttack()
    {   
        int i = UnityEngine.Random.Range(0, 10);
        switch ( i )
        {
            case 0:
                orbShooterAmount = 4;
                combat.ShooterOrbAttack(orbShooterAmount);
                movement.Wander(wanderDuration);
                break;
            case 1:
                orbShooterAmount = 4;
                combat.ShooterOrbAttack(orbShooterAmount);
                movement.ChasePlayer(chaseDuration);
                break;
            case 2:
                movement.Wander(wanderDuration);
                combat.OrbSpiralAttack(orbSpiralDuration, orbSpiralDirectionAmount);
                break;
            case 3:
                movement.ChasePlayer(chaseDuration);
                combat.OrbSpiralAttack(orbSpiralDuration, orbSpiralDirectionAmount);
                break;
            case 4:
                movement.Wander(wanderDuration);
                combat.OrbStreamAttack(orbStreamDuration);
                break;
            case 5:
                movement.ChasePlayer(chaseDuration);
                combat.OrbStreamAttack(orbStreamDuration);
                break;
            case 6:
                movement.Wander(wanderDuration);
                BulletHellCombo1(5);
                break;
            case 7:
                movement.ChasePlayer(chaseDuration);
                BulletHellCombo1(5);
                break;
            case 8:
                movement.Wander(wanderDuration);
                UltraBulletHellCombo(5);
                break;
            case 9:
                movement.ChasePlayer(chaseDuration);
                UltraBulletHellCombo(5);
                break;
        }
    }

    public void discoAuraCombo()
    {
        int i = UnityEngine.Random.Range(0, 5);

        switch (i)
        {
            case 0:
                combat.OrbSpiralAttack(orbSpiralDuration, orbSpiralDirectionAmount);
                combat.DiscoAuraAttack();
                break;
            case 1:
                combat.MinionSpawnChaser();
                combat.DiscoAuraAttack();
                break;
            case 2:
                combat.MinionSpawnShooter();
                combat.DiscoAuraAttack();
                break;
            case 3:
                combat.OrbStreamAttack(orbStreamDuration);
                combat.DiscoAuraAttack();
                break;
            case 4:
                orbShooterAmount = 4;
                combat.ShooterOrbAttack(orbShooterAmount);
                combat.DiscoAuraAttack();
                break;
        }
        
    }

    public void randomShit()
    {
         int i = UnityEngine.Random.Range(0, 10);
        switch (i)
        {
            case 0:
                movement.Wander(wanderDuration);
                break;
            case 1:
                movement.ChasePlayer(chaseDuration);
                break;
            case 2:
                combat.OrbSpiralAttack(orbSpiralDuration, orbSpiralDirectionAmount);
                break;
            case 3:
                combat.OrbStreamAttack(orbStreamDuration);
                break;
            case 4:
                combat.MinionSpawnChaser();
                break;
            case 5:
                combat.MinionSpawnShooter();
                break;
            case 6:
                orbShooterAmount = 4;
                combat.ShooterOrbAttack(orbShooterAmount);
                break;
            case 7:
                BulletHellCombo1(5);
                break;
            case 8:
                UltraBulletHellCombo(5);
                break;
            case 9:
                discoAuraCombo();
                break;
        }
    }

}
