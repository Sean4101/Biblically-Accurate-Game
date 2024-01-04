using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBGMPlayer : MonoBehaviour
{
    private AudioSource music;

    private void Awake()
    {
        music = gameObject.GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        music.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeToBGM()
    {
        music.Stop();
    }

    public void ChangeBack()
    {
        music.time = 0f;
        music.Play();
    }
}
