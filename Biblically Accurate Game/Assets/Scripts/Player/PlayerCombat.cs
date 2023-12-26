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
    public BulletTimeManager bulletTimeManager;
    PlayerMovement playerMovement;

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
    public int currentSkillCharge = 0;
    public bool isSkillReady = false;
    private bool isInSkill = false;
    public int bulletBurstAmount = 15;

    [Header("Bullet Time")]
    public int maxBulletTimeCharge = 35;
    public int currentBulletTimeCharge = 0;
    public bool isBulletTimeReady = false;
    public bool isInBulletTime = false;


    void Awake()
    {
        currentDynamite = 1;
        currentAmmo = 6;
        cameraEffects = Camera.main.GetComponent<CameraEffects>();
        playerMovement = GetComponent<PlayerMovement>();
        currentSkillCharge = 0;
        currentBulletTimeCharge = 0;
        isSkillReady = false;
        isBulletTimeReady = false;
        isInBulletTime = false;
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
        if (Input.GetKeyDown(KeyCode.R) && currentAmmo != 6 && !isReloading)
        {
            interruptReload = false;
            isReloading = true;
            Reload();
        }
        if (Input.GetKeyDown(KeyCode.Q) && isSkillReady)
        {
            Skill();
            isSkillReady = false;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && isBulletTimeReady && !isInBulletTime)
        {
            Debug.Log("Bullet time used");
            BulletTime();
            isBulletTimeReady = false;
        }

        if(isInBulletTime)
        {
            playerMovement.movementSpeed = playerMovement.movementSpeed * Time.timeScale;
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
    private IEnumerator ReloadCoroutine(float delay)
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

            currentAmmo++;

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

    public void ChargeNormalSkill(int amount)
    {
        if (!isInSkill)
        {
            currentSkillCharge += amount;
        }

        if (currentSkillCharge >= maxSkillCharge)
        {
            currentSkillCharge = maxSkillCharge;
            isSkillReady = true;
        }

    }

    public void BulletTimeCharge(int amount)
    {
        bulletBurstAmount += amount;
        if (bulletBurstAmount > maxBulletTimeCharge)
        {
            isBulletTimeReady = true;
            Debug.Log("Bullet time charge is full");
            bulletBurstAmount = maxBulletTimeCharge;
        }

    }
    void Skill()
    {
        StartCoroutine(SkillCoroutine());
        isInSkill = false;
        currentSkillCharge = 0;
    }

    void BulletTime(  )
    {   
        currentBulletTimeCharge = 0;
        isInBulletTime = true;
        bulletTimeManager.DoSlowMotion();
        isInBulletTime = false;
    }
    private IEnumerator SkillCoroutine()
    {   
       
        currentAmmo = 6;
        //let out a burst of bullets which spreads a little bit
        for (int i = 0; i < bulletBurstAmount; i++)
        {        
            isInSkill = true;

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
