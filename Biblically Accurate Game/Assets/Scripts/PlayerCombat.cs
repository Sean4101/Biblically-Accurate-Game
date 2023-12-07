using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [Header("References")]
    public Transform weapon;
    public SpriteRenderer weaponSpriteRenderer;
    public Transform firePoint;

    [Header("Prefabs")]
    public GameObject bulletPrefab;

    [Header("Variables")]
    public float fireForce = 10f;

    private void Update()
    {
        RotateGun();
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void RotateGun()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePos - (Vector2)weapon.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        weapon.rotation = Quaternion.Euler(0, 0, angle);

        if (angle > 90 || angle < -90)
        {
            weaponSpriteRenderer.flipY = true;
        }
        else
        {
            weaponSpriteRenderer.flipY = false;
        }
    }

    void Shoot()
    {
        GameObject pewpew = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        pewpew.GetComponent<Rigidbody2D>().AddForce(firePoint.right * fireForce, ForceMode2D.Impulse);
    }
}
