using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBGMPlayer : MonoBehaviour
{

    static BossBGMPlayer BossBGM;
    private AudioSource music;

    private void Awake()
    {
        if (BossBGM == null)
        {
            BossBGM = this;
            music = BossBGM.GetComponent<AudioSource>();
        }
        else if (BossBGM != this) Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
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
