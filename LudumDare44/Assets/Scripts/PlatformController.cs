using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public enum Direction { Up, Down, Left, Right };

    public Direction direction;
    public float MoveAmount;
    public float Speed;
    public float TimeDelay;

    private float timer;
    private Vector3 positionStart;
    private Vector3 positionEnd;
    private Vector3 moveDirection;


    // Start is called before the first frame update
    void Start()
    {
        positionStart = transform.position;


        switch (direction)
        {
            case Direction.Up:
                moveDirection = Vector3.up;
                break;
            case Direction.Down:
                moveDirection = Vector3.down;
                break;
            case Direction.Left:
                moveDirection = Vector3.left;
                break;
            case Direction.Right:
                moveDirection = Vector3.right;
                break;
            default:
                break;
        }
        positionEnd += moveDirection * MoveAmount;


    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        timer += Time.deltaTime;

        if(Vector3.Distance(positionStart, positionEnd) > MoveAmount && timer != 0)
        {
            if(moveDirection == Vector3.up)
            {
                moveDirection = Vector3.down;
            }
            else if (moveDirection == Vector3.down)
            {
                moveDirection = Vector3.up;
            }
            else if (moveDirection == Vector3.left)
            {
                moveDirection = Vector3.right;
            }
            else if (moveDirection == Vector3.right)
            {
                moveDirection = Vector3.left;
            }
            timer = 0;
        }

        if(timer < TimeDelay)
        { 
            transform.position += moveDirection * Mathf.Sin(Time.time * Speed);
        }
    }
}
