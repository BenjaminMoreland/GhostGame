using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAi : MonoBehaviour
{
    private float latestDirectionChangeTime;
    private readonly float directionChangeTime = 4f;
    private float characterVelocity = 1f;
    private Vector2 movementDirection;
    private Vector2 movementPerSecond;
    public float MaxX;
    public float MinX;
    public float MaxY;
    public float MinY;

    void Start()
    {
        latestDirectionChangeTime = 0f;
        calcuateNewMovementVector();
    }

    void calcuateNewMovementVector()
    {
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

        movementPerSecond = movementDirection * characterVelocity;
    }

    void Update()
    {
        //if the changeTime was reached, calculate a new movement vector
        if (Time.time - latestDirectionChangeTime > directionChangeTime)
        {
            latestDirectionChangeTime = Time.time;
            calcuateNewMovementVector();
        }

        //move enemy: 
        transform.position = new Vector2(transform.position.x + (movementPerSecond.x * Time.deltaTime),
        transform.position.y + (movementPerSecond.y * Time.deltaTime));
    }
}