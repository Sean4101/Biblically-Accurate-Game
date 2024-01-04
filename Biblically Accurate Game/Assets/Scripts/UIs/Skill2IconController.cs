using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill2IconController : MonoBehaviour
{
    public UnityEngine.UI.Slider SliderController;
    public UnityEngine.UI.Image slider;
    public GameObject player;
    PlayerCombat player_statue;
    bool SkillDuration = false;
    public Canvas SubSlider;
    Skill2SubSlider skill2subslider;
    public Image LightUp;
    public float DelayInvisible;
    bool SkillCharge;

    // Start is called before the first frame update
    void Start()
    {
        SkillCharge = false;
        LightUp.enabled = false;
        skill2subslider = SubSlider.GetComponent<Skill2SubSlider>();
        player_statue = player.GetComponent<PlayerCombat>();
        SliderController.value = ((float)player_statue.maxBulletTimeCharge - (float)player_statue.currentBulletTimeCharge) /(float)player_statue.maxBulletTimeCharge;   //q
    }

    // Update is called once per frame
    void Update()
    {
        SliderController.value = ((float)player_statue.maxBulletTimeCharge - (float)player_statue.currentBulletTimeCharge) / (float)player_statue.maxBulletTimeCharge;  //q   
        //Debug.Log($"currentBulletTimeCharge:{player_statue.currentBulletTimeCharge}");
        if ((((float)player_statue.currentBulletTimeCharge) / (float)player_statue.maxBulletTimeCharge) >= 1 && !SkillCharge)
        {
            SkillCharge = true;
            skill_charge();
        }
        if((((float)player_statue.currentBulletTimeCharge) / (float)player_statue.maxBulletTimeCharge) < 1) SkillCharge = false;
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

    public void skill_charge()
    {
        LightUp.enabled = true;
        StartCoroutine(HideLightUpAfterDelat(DelayInvisible));
    }

    IEnumerator HideLightUpAfterDelat(float duration)
    {
        yield return new WaitForSeconds(duration);

        LightUp.enabled = false;
    }
}
