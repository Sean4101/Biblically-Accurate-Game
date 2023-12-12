using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BossHealthBar : MonoBehaviour
{
    public BossStatus bossStatus;

    public TMP_Text healthTextPlaceHolder;

    private void Update()
    {
        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        healthTextPlaceHolder.text = bossStatus.CurrentHealth.ToString();
    }
}
