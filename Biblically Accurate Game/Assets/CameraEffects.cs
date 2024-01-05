using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEffects : MonoBehaviour
{   
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //StartCoroutine( ZoomInCoroutine() );
    }

  
    public void Shake( float duration )
    {
        StartCoroutine( shakeCoroutine( duration ) );
    }

    public void ZoomInOnProtag()
    {
        StartCoroutine( ZoomInCoroutine() );
    }
    IEnumerator shakeCoroutine( float duration )
    {
        float elapsed = 0.0f;

        while ( elapsed < duration )
        {
            float x = Random.Range( -0.1f, 0.1f ) * 0.3f;
            float y = Random.Range( -0.1f, 0.1f ) * 0.3f;

            transform.position = new Vector3( transform.position.x + x, transform.position.y + y, transform.position.z );

            elapsed += Time.deltaTime;

            yield return null;
        }

        //set camera position to (0,0,-10)
        transform.position = new Vector3( 0, 0, -10 );


    }

    IEnumerator ZoomInCoroutine()
    {
        float duration = 0.2f; // Adjust this value for faster or slower zoom
        float elapsed = 0.0f;

        Camera cameraComponent = GetComponent<Camera>();

        float originalOrthoSize = cameraComponent.orthographicSize;
        float targetOrthoSize = 2f; // Adjust this value based on your desired zoom level

        Vector3 originalCamPos = transform.position;
        Vector3 targetCamPos = new Vector3(player.transform.position.x, player.transform.position.y, originalCamPos.z);

        while (elapsed < duration)
        {
            float t = elapsed / duration;

            // Smoothly adjust the orthographic size towards the target size
            cameraComponent.orthographicSize = Mathf.Lerp(originalOrthoSize, targetOrthoSize, t);

            // Smoothly move the camera towards the player's position
            transform.position = Vector3.Lerp(originalCamPos, targetCamPos, t);

            elapsed += Time.deltaTime;
            yield return null;
        }

        // Ensure the camera reaches the exact target orthographic size and position
        cameraComponent.orthographicSize = targetOrthoSize;
        transform.position = targetCamPos;
    }





}
