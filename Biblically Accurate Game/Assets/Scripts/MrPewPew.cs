using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MrPewPew : MonoBehaviour
{
    public Transform characterPoint;
    public Rigidbody2D protagRigid;
    public float speed = 5f;
    Vector2 movement; //vector2 is a 2d vector, it has an x and y value
    public Vector2 protagPos;
    //public gun m1911;

    // Start is called before the first frame update
    void Start()
    {
        this.name = "bird";

    }

    // Update is called once per frame
    void Update() { 
    



    }

    void FixedUpdate()
    {
        //makes gun always follow the bird,while Y axis is slightly lower
        Vector2 pointPos = new Vector2(characterPoint.position.x, characterPoint.position.y - 0.7f);
        gameObject.transform.position = pointPos;

    }
}
