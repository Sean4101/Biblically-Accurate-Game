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
    CameraEffects cameraEffects;
    
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
    public int currentAmmo = 6;
    public float reloadTime = 0.5f;
    public bool isReloading = false;
    private bool interruptReload = false;
    public float pushbackForce = 5f;

    [Header("Dynamite Stats")]
    public int maxDynamite = 3;
    public int currentDynamite = 0;

    [Header("Special Skill")]
    public int maxSkillCharge = 25;
    [SerializeField] private int currentSkillCharge = 0;
    public bool isSkillReady = false;
    private bool isInSkill = false;
    public int bulletBurstAmount = 15;


    void Awake()
    {
        currentDynamite = 1;
        currentAmmo = 6;
        cameraEffects = Camera.main.GetComponent<CameraEffects>();
        currentSkillCharge = 0;
    }
    void Start()
    {
        
    }

    private void Update()
    {
        if (!canControl)
            return;
        RotateGun();
        if (Input.GetMouseButtonDown(0) && currentAmmo != 0 && !isInSkill)
        {   
            interruptReload = true;
            Shoot();
            currentAmmo--;
        }
        if (Input.GetMouseButtonDown(1) && currentDynamite != 0)
        {
            Bomb();
            currentDynamite--;
        }
        if ( Input.GetKeyDown(KeyCode.R) && currentAmmo != 6 && !isReloading )
        {
            interruptReload = false;
            isReloading = true;
            Reload();
        }
        if (Input.GetKeyDown(KeyCode.Q) && isSkillReady)
        {   
            Debug.Log("Skill used");
            Skill();
            isSkillReady = false;
           
            
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
        while (currentAmmo < maxAmmo)
        {   
            yield return new WaitForSeconds(delay);

            //if the player interrupts the reload by shooting, exit the coroutine
            if (interruptReload)
            {
                isReloading = false;
                interruptReload = false; // Reset the flag after interrupting reloading
                yield break; // Exit the coroutine
            }

            currentAmmo ++;
         
        }
        isReloading = false;
    }

    void Shoot()
    {   
        GameObject bulletObj = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletObj.GetComponent<Bullet>();
        bullet.Fire(bulletDamage, bulletSpeed);
        cameraEffects.Shake(0.03f);
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

    public void ChargeSkill( int amount )
    {
        Debug.Log("Charging skill");
        Debug.Log("Current skill charge: " + currentSkillCharge);

        if( !isInSkill )
        {
            currentSkillCharge += amount;
        }
       
        
        if (currentSkillCharge >= maxSkillCharge)
        {
            currentSkillCharge = maxSkillCharge;
            isSkillReady = true;
        }
    }

    void Skill()
    {
        StartCoroutine(SkillCoroutine());
        isInSkill = false;
        currentSkillCharge = 0;
    }

    private IEnumerator SkillCoroutine()
    {   
       
        currentAmmo = 6;
        //let out a burst of bullets which spreads a little bit
        for (int i = 0; i < bulletBurstAmount; i++)
        {
            GameObject bulletObj = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bulletObj.transform.Rotate(0, 0, Random.Range(-20f, 20f));
            cameraEffects.Shake(0.03f);
            Bullet bullet = bulletObj.GetComponent<Bullet>();
            bullet.skillActivated = true;
            bullet.Fire(bulletDamage, bulletSpeed);

            yield return new WaitForSeconds(0.1f);
        }
        isInSkill = false;
    }
}
