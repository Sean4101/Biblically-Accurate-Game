using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    private float mousePosX;
    private float mousePosY;
    private Vector2 crosshairPos;

    public Gun colt;
    public float fireCooldown = 0.1f;

    float fireTime = float.MinValue;

    // Start is called before the first frame update
    void Start()
    {
        mousePosX = Input.mousePosition.x;
        mousePosY = Input.mousePosition.y;
        gameObject.transform.position = new Vector2(mousePosX, mousePosY);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButton(0) && (Time.time - fireTime > fireCooldown))
        {
            colt.Shoot();
            fireTime = Time.time;
        }
        
    }
}
