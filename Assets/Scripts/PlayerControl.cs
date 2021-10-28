using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float Speed = 500;
    Rigidbody2D myRb;

 

    // Start is called before the first frame update
    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
        //grab the camera
        
    }

    //fixed update runs on physics times0

    private void FixedUpdate()
    {
        Vector2 movement = Vector2.zero;
        //grab input from the user
        movement.y = Input.GetAxisRaw("Vertical") * Speed;
        movement.x = Input.GetAxisRaw("Horizontal") * Speed;
        
    //grab input from the user
    float ySpeed = Input.GetAxisRaw("Vertical") * Speed;
    float rotSpeed = Input.GetAxisRaw("Horizontal") * RotationSpeed;

        //Add forces and torque
        myRb.AddForce(movement * Time.fixedDeltaTime);

        //First, get the mouse position
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint( Input.mousePosition );
        Vector3 direction = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, transform.forward);
    }
}