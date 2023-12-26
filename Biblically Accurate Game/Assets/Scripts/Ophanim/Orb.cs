using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{
    public int damage = 1;

    private void Start()
    {
        Invoke("DestroyOrb", 5f);
    }

    private void DestroyOrb()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerStatus>().TakeDamage(damage);
        }
        if (collision.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
