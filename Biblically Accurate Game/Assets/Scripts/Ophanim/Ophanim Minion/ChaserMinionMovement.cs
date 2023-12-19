using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserMinionMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Stats")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private int contactDamage = 1;

    [Header("References")]
    public GameObject player;

   
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsPlayer();
    }

    private void MoveTowardsPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerStatus>().TakeDamage(contactDamage);
            
        }
    }
}
