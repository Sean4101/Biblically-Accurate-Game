using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamiteDropScript : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("References")]
    PlayerCombat playerCombat;

    [Header("Stats")]
    public float dropDistance = 0.5f;
    void Start()
    {
        playerCombat = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombat>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerCombat.AddDynamite();
            Destroy(gameObject);
        }
    }
}
