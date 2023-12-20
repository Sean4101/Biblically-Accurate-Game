using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public PlayerStatus playerStatus;
    public Gradient gradient;
    public Slider PlayerHeathBarSlider;
    public Image fill;

    private void Update()
    {
        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        PlayerHeathBarSlider.value = (float)playerStatus.CurrentHealth / (float)playerStatus.MaxHealth;
        fill.color = gradient.Evaluate(PlayerHeathBarSlider.value);
    }
}
