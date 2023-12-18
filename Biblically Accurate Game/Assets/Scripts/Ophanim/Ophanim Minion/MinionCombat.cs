using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionCombat : MonoBehaviour
{
    [Header("Damage")]
    [SerializeField] private int contactDamage = 1;
    [SerializeField] private int bulletDamage = 1;
    // Start is called before the first frame update
    void Start()
    {
        int attackType = Random.Range(0, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShootAtPlayer()
    {

    }

    public void Spray()
    {

    }
    public void ShootAtPlayerShotGun()
    {

    }
}
