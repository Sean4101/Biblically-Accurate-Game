using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHellSystem_Orb : MonoBehaviour
{
    public int damage = 1;


    [SerializeField] Vector2 moveDirection;
    [SerializeField] float moveSpeed = 5f;
    // Start is called before the first frame update

    private void OnEnable()
    {
        Invoke("Destroy", 3f);
    }
  

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    public void SetMoveDirection( Vector2 dir )
    {
        moveDirection = dir;
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
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
