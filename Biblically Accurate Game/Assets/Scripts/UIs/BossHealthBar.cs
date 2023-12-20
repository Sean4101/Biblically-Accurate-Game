using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class BossHealthBar : MonoBehaviour
{
    public BossStatus bossStatus;
    public UnityEngine.UI.Slider BossHealthBarSlider;

    private void Update()
    {
        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        BossHealthBarSlider.value = (float)bossStatus.CurrentHealth / (float)bossStatus.maxHealth;
    }
}
