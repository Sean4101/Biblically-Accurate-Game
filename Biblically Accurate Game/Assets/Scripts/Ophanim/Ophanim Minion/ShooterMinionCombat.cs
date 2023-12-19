using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterMinionCombat : MonoBehaviour
{
    

    [Header("Reference")]
    public GameObject player;
    public GameObject bulletPrefab;

    [Header("Damage")]
    [SerializeField] private int contactDamage = 1;

    [Header("Bullet Shoot At Player Format")]
    public float shootAtPlayerInterval = 1.0f;
    private float lastShootTime;


    // Start is called before the first frame update
    void Start()
    {
        //int attackType = Random.Range(0, 3);
        player = GameObject.FindGameObjectWithTag("Player");
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

    }
    
    public void ShootAtPlayer()
    {
        StartCoroutine(ShootAtPlayerCoroutine());
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
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerStatus>().TakeDamage(contactDamage);
        }
    }
}
