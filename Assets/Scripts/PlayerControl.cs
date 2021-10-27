using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float Speed = 500;
    public float RotationSpeed = 10;
    Rigidbody2D myRb;

    // Start is called before the first frame update
    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
    }

    //fixed update runs on physics times0

    private void FixedUpdate()
    {
        //grab input from the user
        float ySpeed = Input.GetAxisRaw("Vertical") * Speed;
        float rotSpeed = Input.GetAxisRaw("Horizontal") * RotationSpeed;

        //Add forces and torque
        myRb.AddForce(transform.right * ySpeed * Time.fixedDeltaTime);
        myRb.AddTorque(-rotSpeed * Time.fixedDeltaTime);
    }
}