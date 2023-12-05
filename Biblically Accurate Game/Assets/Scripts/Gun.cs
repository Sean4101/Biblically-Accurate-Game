using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;
    public Rigidbody2D rb;
    public Transform protag;

    public float fireforce;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        //makes gun always follow protag,while Y axis is slightly lower
        Vector2 protagPos = new Vector2(protag.position.x, protag.position.y);
        gameObject.transform.position = protagPos;
        //make rb follow protag
        rb.MovePosition(protagPos);

        //makes gun points to the mouse, while pivot point is set to left
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePos - rb.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //rb.rotation = angle;
        transform.eulerAngles = new Vector3(0, 0, angle);

        //makes firepoint follows gun
        Vector2 firePointPos = new Vector2(firePoint.position.x, firePoint.position.y);
        firePoint.position = firePointPos;

    }
    
    public void Shoot()
    {
        //bulletCount++;
        GameObject pewpew = Instantiate(bullet, firePoint.position, firePoint.rotation);
        pewpew.GetComponent<Rigidbody2D>().AddForce(firePoint.right * fireforce, ForceMode2D.Impulse);
        //create instance of each bullet after instantiating

    }
    
}
