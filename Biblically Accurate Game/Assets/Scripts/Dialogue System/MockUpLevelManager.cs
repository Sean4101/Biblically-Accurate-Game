using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MockUpLevelManager : MonoBehaviour
{   
    public DialogManager dialogManager;
    private bool dialoguesStarted = false;
    // Start is called before the first frame update
    private void Awake()
    {
        dialogManager = FindObjectOfType<DialogManager>();
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!dialoguesStarted)
            {
                dialogManager.StartDialogue();
                dialoguesStarted = true;
            }
        }
    }
}
