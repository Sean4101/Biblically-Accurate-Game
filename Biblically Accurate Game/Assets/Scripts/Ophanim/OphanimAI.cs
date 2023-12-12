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
}
