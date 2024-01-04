using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMusicController : MonoBehaviour
{
    static BackGroundMusicController BGM;
    static AudioSource music;

    private void Awake()
    {
        if (BGM == null)
        {
            BGM = this;
            music = BGM.GetComponent<AudioSource>();
        }
        else if (BGM != this) Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeToBossBGM()
    {
        music.Stop();
    }

    public void ChangeBack()
    {
        music.time = 0f;
        music.Play();
    }
}
