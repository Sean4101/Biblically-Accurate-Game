using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public int MaxHealth = 10;

    public int CurrentHealth { get; private set; }

    void Awake()
    {
        CurrentHealth = MaxHealth;
    }
}
