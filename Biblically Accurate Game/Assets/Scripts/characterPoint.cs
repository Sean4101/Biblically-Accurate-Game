using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterPoint : MonoBehaviour
{
    public Rigidbody2D characterPointrigid;
    public float point_speed = 5f;
    Vector2 movement; //vector2 is a 2d vector, it has an x and y value
    public Vector2 pointPos;
    public Vector2 mousePosi;
    public Vector2 directions;

    public float sprint_speed = 2f;
    //public float sprint_distance = 2f; // Adjust this value to control the sprint distance
    public float sprintDuration = 0.5f; // Adjust this value to control the sprint duration
                                        // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal"); //gets the horizontal input from the input key, this includes the arrow keys and the a and d keys
        movement.y = Input.GetAxis("Vertical");
    }
    void FixedUpdate()
    {
        characterPointrigid.MovePosition(characterPointrigid.position + movement * point_speed * Time.fixedDeltaTime); //"Time.fixedDeltaTime" is the time between each frame, this makes the movement framerate independent

        //update the birdPos variable
        pointPos = characterPointrigid.position;

        mousePosi = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        directions = mousePosi - characterPointrigid.position;
        float angle = Mathf.Atan2(directions.y, directions.x) * Mathf.Rad2Deg - 90f;
        characterPointrigid.rotation = angle;

        if (Input.GetMouseButton(1))
        {
            Sprint();
        }

    }

    // a sprint function that makes the point sprints for a short distance in the direction of the mouse, the distance is controlled by the sprint_distance variable
    public void Sprint()
    {
        characterPointrigid.MovePosition(characterPointrigid.position + directions * sprint_speed * Time.fixedDeltaTime);
    }
}
