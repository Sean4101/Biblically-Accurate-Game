using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{
    private void Start()
    {
        Invoke("DestroyOrb", 5f);
    }

    private void DestroyOrb()
    {
        Destroy(gameObject);
    }
}
