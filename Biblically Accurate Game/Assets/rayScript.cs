using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayScript : MonoBehaviour
{
    public GameObject angel1Attack;
  

    // Start is called before the first frame update
    void Start()
    {
        GameObject foundObjectA = GameObject.Find("angel1Attack");
        if (foundObjectA != null)
        {
            // Access ScriptA from GameObjectA
            tempboss_weapon scriptA = foundObjectA.GetComponent<tempboss_weapon>();

            // Check if the script is found before accessing the value
            if (scriptA != null)
            {
                // Access the value from ScriptA
                int accessedValue = scriptA.auraDuration;
                Invoke("DestroyRay", accessedValue);
                // Do something with the accessed value
            }
          
        }
       
    }

    // Update is called once per frame
    void Update()
    {

    }
    void DestroyRay()
    {
        Destroy(gameObject);
    }

}
