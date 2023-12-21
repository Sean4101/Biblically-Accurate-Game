using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionBullet : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private float speed = 3.5f;
    [SerializeField] private int damage = 1;

    private Vector2 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyBullet", 3f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }

    public void SetMoveDirection(Vector2 dir)
    {
        moveDirection = dir.normalized;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerStatus>().TakeDamage(damage);
            //Destroy(gameObject);
        }
    }
}
