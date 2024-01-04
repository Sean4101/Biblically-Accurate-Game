using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reloadAnimationScript : MonoBehaviour
{
    public PlayerCombat playerCombat;
    Animator reloadAnimator;

    void Start()
    {
        reloadAnimator = GetComponent<Animator>();  // Get the Animator component from the same GameObject
    }

    void Update()
    {
        if (playerCombat.isReloading)
        {
            reloadAnimator.SetBool("isReloading", true);
        }
        else
        {
            reloadAnimator.SetBool("isReloading", false);
        }
    }

    public void fireAnimation()
    {
          reloadAnimator.SetTrigger("fire");
    }
}
