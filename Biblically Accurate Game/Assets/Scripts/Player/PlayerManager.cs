using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    PlayerMovement playerMovement;
    PlayerCombat playerCombat;
    PlayerStatus playerStatus;
    Rigidbody2D rb;

    public bool canControl { private set; get; } = true;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerCombat = GetComponent<PlayerCombat>();
        playerStatus = GetComponent<PlayerStatus>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void EnableControl()
    {
        canControl = true;
        playerMovement.canControl = true;
        playerCombat.canControl = true;
        playerStatus.Invincible = false;
    }

    public void DisableControl()
    {
        rb.velocity = Vector2.zero;
        canControl = false;
        playerMovement.canControl = false;
        playerCombat.canControl = false;
        playerStatus.Invincible = true;
    }
}
