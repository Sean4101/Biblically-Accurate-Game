using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OphanimMovement : MonoBehaviour
{
    [Header("References")]
    public GameObject player;

    [Header("Chase Player")]
    public float chasePlayerSpeed = 2f;

    [Header("Wander")]
    public float wanderSpeed = 1f;
    public float range = 10f;
    public float maxDistance = 5f;
    Vector2 wayPoint;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void ChasePlayer(float duration)
    {
        StartCoroutine(ChasePlayerCoroutine(duration));
    }

    public void Wander(float duration)
    {   
        SetNewDestination();
        StartCoroutine(WanderCoroutine(duration));
    }
    public void StopMovement( float duration )
    {
        
    }

    void SetNewDestination()
    {
        wayPoint = new Vector2(Random.Range(maxDistance,-maxDistance), Random.Range(maxDistance, -maxDistance));
    }
    private IEnumerator ChasePlayerCoroutine(float duration)
    {
        float timer = 0f;
        while (timer < duration)
        {
            Vector3 direction = player.transform.position - transform.position;
            direction.Normalize();
            transform.position += direction * chasePlayerSpeed * Time.deltaTime;
            timer += Time.deltaTime;
            yield return null;
        }
    }

    private IEnumerator WanderCoroutine(float duration)
    {
        float timer = 0f;
        while (timer < duration)
        {
            transform.position = Vector2.MoveTowards(transform.position, wayPoint, wanderSpeed * Time.deltaTime);
        
            if(Vector2.Distance(transform.position, wayPoint) < range)
            {
                SetNewDestination();
            }
            timer += Time.deltaTime; // remove if you want angel to wander forever
            yield return null;
        }
            
    }

    
}
