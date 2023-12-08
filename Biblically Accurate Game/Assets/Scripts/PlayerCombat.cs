using Assets.Scripts.Tree.Projectiles.Modules;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [Header("References")]
    public Transform weapon;
    public SpriteRenderer weaponSpriteRenderer;
    public Transform firePoint;
    private ArcMovement arcMovement;

    [Header("Prefabs")]
    public GameObject bulletPrefab;
    public GameObject dynamitePrefab;

    [Header("Variables")]
    public float fireForce = 10f;
    public float throwForce = 5f;
    

    private void Start()
    {
        arcMovement = GetComponent<ArcMovement>();
    }
    private void Update()
    {
        RotateGun();
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        if (Input.GetMouseButtonDown(1))
        {
            Bomb();
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
        Rigidbody2D pewpewRb = pewpew.GetComponent<Rigidbody2D>();
        pewpewRb.AddForce(firePoint.right * fireForce, ForceMode2D.Impulse);
    }

    void Bomb()
    {   
        
        GameObject boomb = Instantiate(dynamitePrefab, firePoint.position, firePoint.rotation);
        //makes exlosion follow dynamite
        //explosion.transform.parent = boomb.transform;
        Rigidbody2D boombRb = boomb.GetComponent<Rigidbody2D>();
        boombRb.AddForce(firePoint.right * throwForce, ForceMode2D.Impulse);
        
    }
}
