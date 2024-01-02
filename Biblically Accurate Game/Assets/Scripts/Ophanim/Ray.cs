using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct Wave
{
    public float amplitude;
    public float frequency;
    public float phase;
}

public class Ray : MonoBehaviour
{
    public float hueChangeSpeed = 0.5f;
    public float oscillationSpeed = 5f;
    public int damage = 1;

    Collider2D col;
    UniqueColor uniqueColor;
    float currentHue;
    float currentAngle;
    bool activated = false;

    Wave[] waves = new Wave[5]; // Using 5 sine waves

    private void Awake()
    {
        col = GetComponent<Collider2D>();
        uniqueColor = GetComponentInChildren<UniqueColor>();
    }

    private void Start()
    {
        currentHue = Random.Range(0, 360);
        currentAngle = Random.Range(0, 360);
        transform.rotation = Quaternion.Euler(0, 0, currentAngle);
        activated = false;
        col.enabled = false;
        InitializeOscillation();
        //Destroy(gameObject, 7.5f);
    }

    private void Update()
    {
        currentHue += hueChangeSpeed * Time.deltaTime;
        currentHue %= 360;
        Color newColor = Color.HSVToRGB(currentHue / 360f, 1f, 1f);
        if (!activated)
        {
            newColor.a = 0.3f;
        }
        uniqueColor.ChangeColorRuntime(newColor);
        transform.rotation = Quaternion.Euler(0, 0, currentAngle + GetRandomOscillation(Time.time) * oscillationSpeed);
    }

    public void Activate()
    {
        activated = true;
        col.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerStatus>().TakeDamage(damage);
        }
    }

    private void InitializeOscillation()
    {
        for (int i = 0; i < waves.Length; i++)
        {
            waves[i].amplitude = Random.Range(0.5f, 1.5f); // Random amplitude between 0.5 and 1.5
            waves[i].frequency = Random.Range(0.2f, 2.0f); // Random frequency between 0.2 and 2
            waves[i].phase = Random.Range(0, 2 * Mathf.PI); // Random phase between 0 and 2*PI
        }
    }

    float GetRandomOscillation(float currentTime)
    {
        float value = 0f;
        for (int i = 0; i < waves.Length; i++)
        {
            value += waves[i].amplitude * Mathf.Sin(waves[i].frequency * currentTime + waves[i].phase);
        }
        return value;
    }
}
