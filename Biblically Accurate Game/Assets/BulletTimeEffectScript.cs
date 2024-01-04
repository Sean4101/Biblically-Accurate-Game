using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTimeEffectScript : MonoBehaviour
{   
    public float maxScale = 50f;
    public float ExapndSpeed = 300f;
    public float shrinkSpeed = 100f;
    public bool expandeEffectDone = false;
    public bool shrinkEffectDone = false;
    public bool bulletTimeOver = false;
    // Start is called before the first frame update
    void Start()
    {
        //Becomes a child of the player tag
        transform.parent = GameObject.FindGameObjectWithTag("Player").transform;
        expandeEffectDone = false;
        shrinkEffectDone = false;
    }

    // Update is called once per frame
    void Update()
    {
        //start expanding the sprite
        if(transform.localScale.x < maxScale && !expandeEffectDone)
        {
            transform.localScale += new Vector3(ExapndSpeed, ExapndSpeed, 0f) * Time.deltaTime;
        }
        else
        {   
            expandeEffectDone = true;  
            shrinkEffect();
        }

       
    }

    public void shrinkEffect()
    {
        
        transform.localScale -= new Vector3(ExapndSpeed, ExapndSpeed, 0f) * Time.deltaTime;
        if (transform.localScale.x <= 0f)
        {
            shrinkEffectDone = true;
            Destroy(gameObject);
        }
        
        
    }
}
