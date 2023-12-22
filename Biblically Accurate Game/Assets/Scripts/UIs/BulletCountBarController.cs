using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletCountBarController : MonoBehaviour
{
    public UnityEngine.UI.Slider BulletCountBarSlider;
    public Gradient gradient;
    public Image fill;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        BulletCountBarSlider.value = player.GetComponent<PlayerCombat>().currentAmmo;
        fill.color = gradient.Evaluate(BulletCountBarSlider.value/6);
    }
}
