using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Start()
    {
        Invoke("DestroyBullet", 3f); //2f is the time before the bullet is destroyed
    }

    // Update is called once per frame
    void Update()
    {

    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
