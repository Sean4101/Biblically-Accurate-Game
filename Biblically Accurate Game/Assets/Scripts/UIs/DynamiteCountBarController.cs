using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamiteCountBarController : MonoBehaviour
{
    public Image BarFill1;
    public Image BarFill2;
    public Image BarFill3;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int DynamiteCount = player.GetComponent<PlayerCombat>().currentDynamite;
        if(DynamiteCount >= 1) BarFill1.gameObject.SetActive(true);
        else BarFill1.gameObject.SetActive(false);
        if(DynamiteCount >= 2) BarFill2.gameObject.SetActive(true);
        else BarFill2.gameObject.SetActive(false);
        if(DynamiteCount >= 3) BarFill3.gameObject.SetActive(true);
        else BarFill3 .gameObject.SetActive(false);
    }
}
