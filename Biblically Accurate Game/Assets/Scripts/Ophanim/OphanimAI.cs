using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OphanimAI : MonoBehaviour
{
    OphanimCombat combat;
    OphanimMovement movement;
    BossStatus status;

    private void Awake()
    {
        combat = GetComponent<OphanimCombat>();
        movement = GetComponent<OphanimMovement>();
        status = GetComponent<BossStatus>();
    }

    public void EnableAI()
    {
        StartCoroutine(AICoroutine());
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
}
