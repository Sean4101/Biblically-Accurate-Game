using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealthBar : MonoBehaviour
{
    public PlayerStatus playerStatus;

    public TMP_Text healthTextPlaceHolder;

    private void Update()
    {
        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        healthTextPlaceHolder.text = playerStatus.CurrentHealth.ToString();
    }
}
