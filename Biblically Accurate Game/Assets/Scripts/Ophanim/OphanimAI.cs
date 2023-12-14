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
            combat.OrbStreamAttack(5f);
            yield return new WaitForSeconds(10f);
            combat.OrbSpiralAttack(5f, 8);
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
}
