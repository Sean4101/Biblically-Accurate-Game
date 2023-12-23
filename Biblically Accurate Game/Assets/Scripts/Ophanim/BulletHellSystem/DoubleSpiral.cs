using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleSpiral : MonoBehaviour
{
    private float angle = 0f;

    private Vector2 bulletMoveDirection;
    // Start is called before the first frame update
    void Start()
    {   
        InvokeRepeating("Fire", 0f, 0.1f);
    }

    private void Fire()
    {

        for (int i = 0; i < 2; i++)
        {
            float bulletDirX = transform.position.x + Mathf.Sin(((angle + 180f * i) * Mathf.PI) / 180f);
            float bulletDirY = transform.position.y + Mathf.Cos(((angle + 180f * i) * Mathf.PI) / 180f);

            Vector3 bulletMoveVector = new Vector3(bulletDirX, bulletDirY, 0f);
            Vector2 bulletDir = (bulletMoveVector - transform.position).normalized;

            GameObject bullet = BulletHellSystem_BulletPool.bulletPoolInstance.GetBullet();
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            bullet.SetActive(true);
            bullet.GetComponent<BulletHellSystem_Orb>().SetMoveDirection(bulletDir);
        }

        angle += 10f;

        if (angle >= 360f)
        {
            angle = 0f;
        }
    }
}
