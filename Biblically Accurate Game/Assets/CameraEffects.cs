using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEffects : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shake( float duration )
    {
        StartCoroutine( shakeCoroutine( duration ) );
    }

    IEnumerator shakeCoroutine( float duration )
    {
        float elapsed = 0.0f;
        Vector3 originalCamPos = transform.position;

        while ( elapsed < duration )
        {
            float x = Random.Range( -0.1f, 0.1f ) * 0.5f;
            float y = Random.Range( -0.1f, 0.1f ) * 0.5f;

            transform.position = new Vector3( transform.position.x + x, transform.position.y + y, transform.position.z );

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.position = originalCamPos;
    }
}
