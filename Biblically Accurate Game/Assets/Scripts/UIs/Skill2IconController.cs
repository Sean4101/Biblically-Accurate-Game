using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill2IconController : MonoBehaviour
{
    public UnityEngine.UI.Slider SliderController;
    public UnityEngine.UI.Image slider;
    public UnityEngine.UI.Image back;
    public GameObject player;
    PlayerCombat player_statue;
    // Start is called before the first frame update
    void Start()
    {
        player_statue = player.GetComponent<PlayerCombat>();
        SliderController.fillRect = slider.rectTransform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
