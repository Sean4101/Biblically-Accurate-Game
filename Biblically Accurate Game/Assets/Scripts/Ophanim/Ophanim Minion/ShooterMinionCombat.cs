using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterMinionCombat : MonoBehaviour
{
    

    [Header("Reference")]
    public GameObject player;
    public GameObject bulletPrefab;
    public Transform boss;


    [Header("Stats")]
    [SerializeField] private int contactDamage = 1;
    [SerializeField] private float healAmount = 2f;
    [SerializeField] private float healBossDelay = 6.0f;
    [SerializeField] private float speed = 5f;
    private bool isHealing = false;


    [Header("Bullet Shoot At Player Format")]
    public float shootAtPlayerInterval = 1.0f;
    private float lastShootTime;


    // Start is called before the first frame update
    void Start()
    {
        //int attackType = Random.Range(0, 3);
        player = GameObject.FindGameObjectWithTag("Player");
        boss = GameObject.Find("Disco Angel Ophanimim").transform;
        Invoke("healBoss", healBossDelay);
    }

    // Update is called once per frame
    void Update()
    {
        //Spray();
        if (Time.time - lastShootTime >= shootAtPlayerInterval)
        {
            ShootAtPlayer();
            lastShootTime = Time.time;
        }
        if (isHealing)
        {
            MoveTowardsBoss();
            healBoss();
        }

    }
    
    public void ShootAtPlayer()
    {
        StartCoroutine(ShootAtPlayerCoroutine());
    }

    private void MoveTowardsBoss()
    {
        transform.position = Vector2.MoveTowards(transform.position, boss.position, speed * Time.deltaTime);
    }
    private IEnumerator ShootAtPlayerCoroutine()
    {   
        //Instantiate bullet that points at player
        GameObject shootAtPlayerBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        shootAtPlayerBullet.GetComponent<MinionBullet>().SetMoveDirection((player.transform.position - transform.position).normalized);
        yield return new WaitForSeconds(shootAtPlayerInterval);
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
