using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoArenaPad : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public bool isActivated = false;

    public float deactivatedValue = 0.5f;
    public float activatedValue = 1f;
    public float toBeActivatedValue = 0.75f;
    public float saturation = 0.8f;

    float randomHue;

    public void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        randomHue = Random.Range(0f, 1f);
        Deactivate();
    }

    public void PrepareActivation()
    {
        StartCoroutine(ActivationCoroutine());
    }

    IEnumerator ActivationCoroutine()
    {
        ToBeActivated();
        yield return new WaitForSeconds(1.5f);
        Activate();
        yield return new WaitForSeconds(0.5f);
        Deactivate();
    }

    void ToBeActivated()
    {
        spriteRenderer.color = Color.HSVToRGB(randomHue, saturation, toBeActivatedValue);
    }

    void Activate()
    {
        isActivated = true;
        spriteRenderer.color = Color.HSVToRGB(randomHue, saturation, activatedValue);
    }

    void Deactivate()
    {
        isActivated = false;
        spriteRenderer.color = Color.HSVToRGB(randomHue, saturation, deactivatedValue);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (isActivated)
            {
                other.GetComponent<PlayerStatus>().TakeDamage(1);
            }
        }
    }
}
