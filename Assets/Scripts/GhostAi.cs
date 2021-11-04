/********************

By: Benjamin Moreland and Ryan Scheppler

Last Edited: 11/1/2021

Description: Ai to make object move in random direction then stop for 1.5 seconds

********************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAi : MonoBehaviour
{
    public float characterSpeed = 1f;
    private Vector2 movementDirection;
    private Vector2 movementPerSecond;
    public float MaxX;
    public float MinX;
    public float MaxY;
    public float MinY;
    public Rigidbody2D MyRb;
    public float pauseTime = 1.5f;

    void Start()
    {
        //new movement vector is called at the beginning of the game with a speed and direction of 0. So it doesn't move.
        StartCoroutine(calcuateNewMovementVector(0));
        //get rigidbody
        MyRb = GetComponent<Rigidbody2D>();
    }

    //IEnumerator is used as the base of the function for calculateNewMovementVector,
    //and the function calls in a new variable which is a float called pause to stop the object.
    IEnumerator calcuateNewMovementVector(float pause)
    {
        //return the WaitForSeconds pause thing to the user with a
        //WaitForSeconds variable that calls in the pause float.
        yield return new WaitForSeconds(pause);
        //create a random direction vector with the magnitude of 1, later multiply it with the velocity of the enemy
        movementDirection = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;

        // if the AI's movement has exceeded the maximum distance along the x or y axis, it flips the direction it's moving
        if(transform.position.x > MaxX && movementDirection.x > 0)
        {
            movementDirection.x = -movementDirection.x;
        }

        if (transform.position.y > MaxY && movementDirection.y > 0)
        {
            movementDirection.y = -movementDirection.y;
        }

        if (transform.position.x < MinX && movementDirection.x < 0)
        {
            movementDirection.x = -movementDirection.x;
        }

        if (transform.position.y < MinY && movementDirection.y < 0)
        {
            movementDirection.y = -movementDirection.y;
        }

        movementPerSecond = movementDirection * characterSpeed;
    }

    void FixedUpdate()
    {
        /*starts coroutines for each axis with a max and min and the pauseTime function stops
         the object for that period of time defined before the start function with 1.5 seconds as the wait time. */
        if (transform.position.x > MaxX && movementPerSecond.x > 0)
        {
            StartCoroutine(calcuateNewMovementVector(pauseTime));

            movementPerSecond = Vector2.zero;
        }

        if (transform.position.y > MaxY && movementPerSecond.y > 0)
        {
            StartCoroutine(calcuateNewMovementVector(pauseTime));

            movementPerSecond = Vector2.zero;
        }

        if (transform.position.x < MinX && movementPerSecond.x < 0)
        {
            StartCoroutine(calcuateNewMovementVector(pauseTime));

            movementPerSecond = Vector2.zero;
        }

        if (transform.position.y < MinY && movementPerSecond.y < 0)
        {
            StartCoroutine(calcuateNewMovementVector(pauseTime));

            movementPerSecond = Vector2.zero;
        }

        //move enemy: 
        MyRb.velocity = movementPerSecond;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Flashlight"))
        {
            StopAllCoroutines();
            MyRb.velocity = Vector2.zero;
            movementPerSecond = Vector2.zero;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Flashlight"))
        {
            StartCoroutine(calcuateNewMovementVector(4));
        }
    }
}