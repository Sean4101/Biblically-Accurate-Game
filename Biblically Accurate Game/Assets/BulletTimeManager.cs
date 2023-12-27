using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTimeManager : MonoBehaviour
{   
    public float slowdownFactor = 0.001f;
    public float slowdownLength = 10f;
    public float timeLeft;

    private void Start()
    {
        timeLeft = slowdownLength;
    }

    void Update()
    {   
        Debug.Log(timeLeft);
        timeLeft -= Time.deltaTime;
        Time.timeScale += (1f / slowdownLength) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
        if (timeLeft <= 0)
        {
            timeLeft = slowdownLength;
        }
    }
    public void DoSlowMotion()
    {
        Time.timeScale = slowdownFactor;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }
   
}
