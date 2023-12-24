using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDropSript : MonoBehaviour
{
    [Header("References")]
    PlayerStatus playerStatus;

    [Header("Stats")]
    public int playerHealAmount = 1;
    // Start is called before the first frame update
    void Start()
    {
        playerStatus = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatus>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerStatus.playerHeal(playerHealAmount);
            Destroy(gameObject);
        }
    }
}
