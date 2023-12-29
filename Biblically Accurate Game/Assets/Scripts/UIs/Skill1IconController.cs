using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill1IconController : MonoBehaviour
{
    public GameObject player;
    PlayerCombat player_statue;
    public UnityEngine.UI.Slider slider;
    public UnityEngine.UI.Image LightUp;
    bool SkillReadyShow = false;
    float timer = 0f;
    public float DelayInvisible;
    // Start is called before the first frame update
    void Start()
    {
        player_statue = player.GetComponent<PlayerCombat>();
        LightUp.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 1f)timer = 0f;
        slider.value = (float)(player_statue.maxSkillCharge - player_statue.currentSkillCharge)/(float)player_statue.maxSkillCharge;
        if(SkillReadyShow == false && player_statue.currentSkillCharge >= player_statue.maxSkillCharge) show_LightUp();
        if (player_statue.currentSkillCharge < player_statue.maxSkillCharge) SkillReadyShow = false;
    }

    void show_LightUp()
    {
        SkillReadyShow = true;
        timer = 0f;
        LightUp.enabled = true;
        StartCoroutine(HideLightUpAfterDelat(DelayInvisible));
    }

    IEnumerator HideLightUpAfterDelat(float duration)
    {
        yield return new WaitForSeconds(duration);

        LightUp.enabled = false;
    }
}
