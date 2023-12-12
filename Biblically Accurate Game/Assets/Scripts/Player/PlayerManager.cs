using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    PlayerMovement playerMovement;
    PlayerCombat playerCombat;
    Rigidbody2D rb;

    public bool canControl { private set; get; } = true;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerCombat = GetComponent<PlayerCombat>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void EnableControl()
    {
        canControl = true;
        playerMovement.enabled = true;
        playerCombat.enabled = true;
    }

    public void DisableControl()
    {
        rb.velocity = Vector2.zero;
        canControl = false;
        playerMovement.enabled = false;
        playerCombat.enabled = false;
    }
}
