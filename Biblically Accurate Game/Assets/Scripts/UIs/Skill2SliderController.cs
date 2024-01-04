using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill2SliderController : MonoBehaviour
{
    public Slider slider;
    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        image.color = Color.white;
        slider.value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void skill_duration_updatge(float number)
    {
        image.color = Color.red;
        slider.value = number;
    }

    public void skill_stop()
    {
        image.color = Color.white;
        slider.value = 1;
    }
}
