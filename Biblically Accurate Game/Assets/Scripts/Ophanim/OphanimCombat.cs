using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OphanimCombat : MonoBehaviour
{
    public Transform player;

    [Header ("Contact Damage")]
    public int ophanimContactDamage = 1;

    [Header("Orb Attack")]
    public GameObject orbPrefab;
    public GameObject foreshadowOrbPrefab;
    public GameObject shooterOrbPrefab;

    [Header("Orb Stream Attack")]
    public float streamOrbSpeed = 3f;
    public float orbStreamAttackInterval = 0.2f;

    [Header("Orb Spiral Attack")]
    public Transform orbSpiralOrientation;
    public float orbSpiralOrientationRotationSpeed = 3f;
    public float spiralOrbSpeed = 3f;
    public float orbSpiralAttackInterval = 0.2f;

    [Header("Minion Spawning")]
    public GameObject minionShooter;
    public GameObject minionChaser;
    public int minionSpawnAmount = 4;
    public float minionSpacing = 1f;

    [Header("Shooter Orb Attack")]
    public float shooterOrbSpeed = 1f;
    public int shooterOrbAmount = 4;
    public float shooterOrbDelay = 1.5f;

    [Header("Disco Aura Attack")]
    public GameObject discoAuraObj;
    public GameObject discoRayPrefab;
    public float discoAuraAttackPreparationDuration = 1f;
    public float discoAuraAttackDuration = 7.5f;
    public int raysToSpawn = 5;


    [Header("Sound Effects")]
    public AudioSource orbAttackAudioSource;
    public AudioClip orbAttackAudioClip;
    public AudioSource spawnAudioSource;
    public AudioClip spawnAudioClip;

    private void Update()
    {
        orbSpiralOrientation.Rotate(0f, 0f, orbSpiralOrientationRotationSpeed * Time.deltaTime);
    }

    
    public void OrbStreamAttack(float duration)
    {
        StartCoroutine(OrbStreamAttackCoroutine(duration));
    }

    private IEnumerator OrbStreamAttackCoroutine(float duration)
    {
        // Foreshadowing for 1 second
        GameObject foreshadowingOrb = Instantiate(foreshadowOrbPrefab, transform.position, Quaternion.identity);
        SpriteRenderer orbRenderer = foreshadowingOrb.GetComponent<SpriteRenderer>();
        orbRenderer.color = new Color(1f, 1f, 1f, 0f);

        float foreshadowingTimeLeft = 1f;
        while (foreshadowingTimeLeft > 0)
        {
            Vector2 playerDirection = player.position - transform.position;
            Vector2 followPoint = transform.position + (Vector3)playerDirection.normalized * 1.5f;
            foreshadowingOrb.transform.position = followPoint;
            orbRenderer.color = new Color(1f, 1f, 1f, (1 - foreshadowingTimeLeft) / 1f);

            foreshadowingTimeLeft -= Time.deltaTime;
            yield return null;
        }
        Destroy(foreshadowingOrb);

        // Attack
        for (float i = 0; i < duration; i += orbStreamAttackInterval)
        {
            Vector2 playerDirection = player.position - transform.position;
            Vector2 spawnPoint = transform.position + (Vector3)playerDirection.normalized * 1.5f;
            GameObject orbStream = Instantiate(orbPrefab, spawnPoint, Quaternion.identity);
            Rigidbody2D orbRB = orbStream.GetComponent<Rigidbody2D>();
            orbRB.velocity = playerDirection.normalized * streamOrbSpeed;
            yield return new WaitForSeconds(orbStreamAttackInterval);
        }
    }

    public void OrbSpiralAttack(float duration, int totalAngles)
    {
        StartCoroutine(OrbSpiralAttackCoroutine(duration, totalAngles));
    }

    // I don't like this coroutine. It's too long and does too many things. :(
    private IEnumerator OrbSpiralAttackCoroutine(float duration, int totalAngles)
    {
        float angleInterval = 360f / totalAngles;

        // Foreshadowing for 1 second
        List<GameObject> foreshadowingOrbs = new List<GameObject>();
        for (int i = 0; i < totalAngles; i++)
        {
            GameObject foreshadowingOrb = Instantiate(foreshadowOrbPrefab, transform.position, Quaternion.identity);
            SpriteRenderer orbRenderer = foreshadowingOrb.GetComponent<SpriteRenderer>();
            orbRenderer.color = new Color(1f, 1f, 1f, 0f);
            foreshadowingOrbs.Add(foreshadowingOrb);
        }

        float foreshadowingTimeLeft = 1f;
        while (foreshadowingTimeLeft > 0)
        {
            for (int i = 0; i < totalAngles; i++)
            {
                Vector2 direction = (Vector2)(Quaternion.Euler(0f, 0f, angleInterval * i) * orbSpiralOrientation.up);
                Vector2 followPoint = (Vector2)transform.position + direction * 1.5f;
                foreshadowingOrbs[i].transform.position = followPoint;
                SpriteRenderer orbRenderer = foreshadowingOrbs[i].GetComponent<SpriteRenderer>();
                orbRenderer.color = new Color(1f, 1f, 1f, (1 - foreshadowingTimeLeft) / 1f);
            }

            foreshadowingTimeLeft -= Time.deltaTime;
            yield return null;
        }

        foreach (GameObject foreshadowingOrb in foreshadowingOrbs)
        {
            Destroy(foreshadowingOrb);
        }

        // Attack
        for (float i = 0; i < duration; i += orbSpiralAttackInterval)
        {
            for (int j = 0; j < totalAngles; j++)
            {
                Vector2 direction = (Vector2)(Quaternion.Euler(0f, 0f, angleInterval * j) * orbSpiralOrientation.up);
                Vector2 spawnPoint = (Vector2)transform.position + direction * 1.5f;
                GameObject orb = Instantiate(orbPrefab, spawnPoint, Quaternion.identity);
                orbAttackAudioSource.clip = orbAttackAudioClip;
                PlayOrbSound();
                Rigidbody2D orbRB = orb.GetComponent<Rigidbody2D>();
                orbRB.velocity = direction.normalized * spiralOrbSpeed;
            }
            yield return new WaitForSeconds(orbSpiralAttackInterval);
        }
    }

    public void GuitarThrowAttack()
    {
        StartCoroutine(GuitarThrowAttackCoroutine());
    }

    private IEnumerator GuitarThrowAttackCoroutine()
    {
        Debug.Log("Guitar Throw Attack");
        yield return null;
    }

    public void MinionSpawnShooter()
    {
        spawnAudioSource.clip = spawnAudioClip;
        PlaySpawnSound();
        for (int i = 0; i < minionSpawnAmount; i++)
        {
            if (i % 2 == 0) 
            {   
                // Spawn minion on right side
                Vector3 spawnPosition = transform.position + new Vector3(i * minionSpacing + 1.5f, 0f, 0f);
                Instantiate(minionShooter, spawnPosition, Quaternion.identity);
            }
            else if (i % 2 == 1) 
            {   
                // Spawn minion on left side
                Vector3 spawnPosition = transform.position + new Vector3(-i * minionSpacing - 1.5f, 0f, 0f);
                Instantiate(minionShooter, spawnPosition, Quaternion.identity);
            }
        }

    }

    public void MinionSpawnChaser()
    {   
        spawnAudioSource.clip = spawnAudioClip;
        PlaySpawnSound();
        Instantiate(minionChaser, transform.position, Quaternion.identity);
    }
    
    public void ShooterOrbAttack( int amount)
    {
        StartCoroutine(ShooterOrbAttackCoroutine(amount, shooterOrbDelay));
    }

    private IEnumerator ShooterOrbAttackCoroutine(int times, float delay)
    {
        // Attack
        for (int i = 0; i < times; i ++)
        {
            Vector2 playerDirection = player.position - transform.position;
            Vector2 spawnPoint = transform.position + (Vector3)playerDirection.normalized * 1.5f;
            GameObject shooterOrnAtk = Instantiate(shooterOrbPrefab, spawnPoint, Quaternion.identity);
            orbAttackAudioSource.clip = orbAttackAudioClip;
            PlayOrbSound();
            orbAttackAudioSource.clip = orbAttackAudioClip;
            PlayOrbSound();
            Rigidbody2D orbRB = shooterOrnAtk.GetComponent<Rigidbody2D>();
            orbRB.velocity = playerDirection.normalized * shooterOrbSpeed;
            yield return new WaitForSeconds(delay);
        }
    }

    public void DiscoAuraAttack()
    {
        StartCoroutine(DiscoAuraAttackCoroutine());
    }

    List<GameObject> discoRays = new List<GameObject>();

    private IEnumerator DiscoAuraAttackCoroutine()
    {
        discoAuraObj.SetActive(true);
        for (int i = 0; i < raysToSpawn; i++)
        {
            GameObject discoRay = Instantiate(discoRayPrefab, discoAuraObj.transform);
            discoRays.Add(discoRay);
        }
        yield return new WaitForSeconds(discoAuraAttackPreparationDuration);
        foreach (GameObject discoRay in discoRays)
        {
            discoRay.GetComponent<Ray>().Activate();
        }
        yield return new WaitForSeconds(discoAuraAttackDuration);
        discoAuraObj.SetActive(false);
        foreach (GameObject discoRay in discoRays)
        {
            Destroy(discoRay);
        }
        discoRays.Clear();
    }

    //contact damage
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.SendMessage("TakeDamage", ophanimContactDamage);
        }
    }

   void PlayOrbSound()
    {
        orbAttackAudioSource.time = 0f;
        orbAttackAudioSource.volume = 0.5f;
        orbAttackAudioSource.pitch = 1f;

        orbAttackAudioSource.Play();
    }

    void PlaySpawnSound()
    {
        spawnAudioSource.time = 0f;
        spawnAudioSource.volume = 0.6f;
        spawnAudioSource.pitch = 1f;

        spawnAudioSource.Play();
    }
}
