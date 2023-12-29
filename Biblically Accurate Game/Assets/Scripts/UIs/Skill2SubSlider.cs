using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill2SubSlider : MonoBehaviour
{
    public Slider slider;
    public Image Back;
    // Start is called before the first frame update
    void Start()
    {
        Back.color = Color.blue;
        slider.value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SkillDuration(float value)
    {
        Back.color = Color.red;
        slider.value = value;
    }

    public void SkillStop()
    {
        Back.color = Color.blue;
        slider.value = 1;
    }
}
