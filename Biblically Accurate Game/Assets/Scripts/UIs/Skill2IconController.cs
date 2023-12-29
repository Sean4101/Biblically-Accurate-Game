using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill2IconController : MonoBehaviour
{
    public UnityEngine.UI.Slider SliderController;
    public UnityEngine.UI.Image slider;
    public GameObject player;
    PlayerCombat player_statue;
    bool SkillDuration = false;
    public Canvas SubSlider;
    Skill2SubSlider skill2subslider;

    // Start is called before the first frame update
    void Start()
    {
        skill2subslider = SubSlider.GetComponent<Skill2SubSlider>();
        player_statue = player.GetComponent<PlayerCombat>();
        SliderController.value = ((float)player_statue.maxBulletTimeCharge - (float)player_statue.currentBulletTimeCharge) /(float)player_statue.maxBulletTimeCharge;   //q
    }

    // Update is called once per frame
    void Update()
    {
        SliderController.value = ((float)player_statue.maxBulletTimeCharge - (float)player_statue.currentBulletTimeCharge) / (float)player_statue.maxBulletTimeCharge;  //q
        //Debug.Log($"currentBulletTimeCharge:{player_statue.currentBulletTimeCharge}");
    }

    public void SkillRun()
    {
        skill2subslider.SkillDuration(1);
        SkillDuration = true;
    }

    public void SkillRemainTime(float time)
    {
        if (SkillDuration)skill2subslider.SkillDuration(time);
    }
    public void SkillStop() {
        if (SkillDuration)
        {
            SkillDuration = false;
            skill2subslider.SkillStop();
        }
    }
}
