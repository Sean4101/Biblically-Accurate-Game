using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill1IconController : MonoBehaviour
{
    public GameObject player;
    PlayerCombat player_statue;
    public UnityEngine.UI.Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        player_statue = player.GetComponent<PlayerCombat>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = (float)(player_statue.maxSkillCharge - player_statue.currentSkillCharge)/(float)player_statue.maxSkillCharge;
    }
}
