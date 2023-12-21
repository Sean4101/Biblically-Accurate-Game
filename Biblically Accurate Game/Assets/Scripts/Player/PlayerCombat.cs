using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public bool canControl = true;

    [Header("References")]
    public Transform weapon;
    public SpriteRenderer weaponSpriteRenderer;
    public Transform firePoint;

    [Header("Prefabs")]
    public GameObject bulletPrefab;
    public GameObject dynamitePrefab;

    [Header("Shooting Attack")]
    public int bulletDamage = 1;
    public float bulletSpeed = 10f;

    [Header("Dynamite Attack")]
    public float dynamiteForce = 5f;
    public float dynamiteTorque = 5f;

    [Header("Gun Stats")]
    public int maxAmmo = 6;
    public float reloadTime = 2f;

    [Header("Dynamite Stats")]
    public int maxDynamite = 3;
    public int currentDynamite = 0;

    void Start()
    {
        currentDynamite = 1;
        maxAmmo = 6;
    }

    private void Update()
    {
        if (!canControl)
            return;
        RotateGun();
        if (Input.GetMouseButtonDown(0) && maxAmmo != 0)
        {
            Shoot();
            maxAmmo--;
        }
        if (Input.GetMouseButtonDown(1) && currentDynamite != 0)
        {
            Bomb();
            currentDynamite--;
        }

        if (Input.GetKeyDown(KeyCode.R) && maxAmmo != 6)
        {
            Reload();
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

    void Reload()
    {
        StartCoroutine(ReloadCoroutine(reloadTime));
    }
    private IEnumerator ReloadCoroutine( float delay)
    {
        yield return new WaitForSeconds(delay);
        maxAmmo = 6;
    }

    void Shoot()
    {   
        GameObject bulletObj = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletObj.GetComponent<Bullet>();
        bullet.Fire(bulletDamage, bulletSpeed);
    }

    void Bomb()
    {
        GameObject dynamite = Instantiate(dynamitePrefab, firePoint.position, firePoint.rotation);

        Rigidbody2D dynamiteRb = dynamite.GetComponent<Rigidbody2D>();
        dynamiteRb.AddForce(firePoint.right * dynamiteForce, ForceMode2D.Impulse);
    }

    public void AddDynamite()
    {
        currentDynamite++;
        if (currentDynamite > maxDynamite)
        {
            currentDynamite = maxDynamite;
        }
            
    }
}
