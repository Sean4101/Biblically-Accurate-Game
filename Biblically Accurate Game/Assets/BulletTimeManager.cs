using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTimeManager : MonoBehaviour
{   
    public float slowdownFactor = 0.001f;
    public float slowdownLength = 10f;
    public float timeLeft;
    public bool slowMotionOver = false;
    public Canvas Skill2;

    private void Start()
    {
        timeLeft = slowdownLength;
    }

    void Update()
    {   
        timeLeft -= Time.deltaTime;
        Time.timeScale += (1f / slowdownLength) * Time.unscaledDeltaTime;
        Skill2.GetComponent<Skill2IconController>().SkillRemainTime((1f - Time.timeScale) > 0 ? (1f - Time.timeScale) : 0);
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
       
        if (Time.timeScale == 1)
        {
            Skill2.GetComponent<Skill2IconController>().SkillStop();
            slowMotionOver = true;
        }

        Time.fixedDeltaTime = Time.timeScale * 0.02f;
        if (timeLeft <= 0)
        {
            timeLeft = slowdownLength;
        }
    }
    public void DoSlowMotion()
    {   
        slowMotionOver = false;
        Skill2.GetComponent<Skill2IconController>().SkillRun();
        Time.timeScale = slowdownFactor;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
        //detect if the effect is done
        
    }
   
}
