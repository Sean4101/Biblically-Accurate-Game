using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserMinionMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Stats")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private int contactDamage = 1;
    [SerializeField] private float healAmount = 2f;
    [SerializeField] private float healBossDelay = 6.0f;

    private bool isHealing = false;
    [Header("References")]
    public GameObject player;
    public Transform boss;
   
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //boss is the gameonject with name "Disco Angel Ophanimim"
        boss = GameObject.Find("Disco Angel Ophanimim").transform;

        Invoke("healBoss", healBossDelay);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isHealing)
        {
            MoveTowardsPlayer();
        }
        else if (isHealing)
        {   
            MoveTowardsBoss();
            healBoss();
        }
       
    }

    private void MoveTowardsPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void MoveTowardsBoss()
    {
        transform.position = Vector2.MoveTowards(transform.position, boss.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerStatus>().TakeDamage(contactDamage);
        }
        else if (collision.gameObject.name == "Disco Angel Ophanimim" && isHealing)
        {
            Debug.Log("healing boss");
            collision.gameObject.GetComponent<BossStatus>().Heal();
            Destroy(gameObject);
        }
    }

    private void healBoss()
    {
        //move towards boss
        isHealing = true;  
    }
}
