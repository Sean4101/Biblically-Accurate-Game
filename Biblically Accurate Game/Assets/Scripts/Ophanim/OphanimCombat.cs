using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OphanimCombat : MonoBehaviour
{
    public Transform player;

    [Header("Orb Attack")]
    public GameObject orbPrefab;

    [Header("Orb Stream Attack")]
    public float streamOrbSpeed = 3f;
    private float orbStreamAttackInterval = 0.2f;

    [Header("Orb Spiral Attack")]
    public Transform orbSpiralOrientation;
    public float orbSpiralOrientationRotationSpeed = 3f;
    public float spiralOrbSpeed = 3f;
    private float orbSpiralAttackInterval = 0.2f;

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
        GameObject foreshadowingOrb = Instantiate(orbPrefab, transform.position, Quaternion.identity);
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
            GameObject foreshadowingOrb = Instantiate(orbPrefab, transform.position, Quaternion.identity);
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
}
