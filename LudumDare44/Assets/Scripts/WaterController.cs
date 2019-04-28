using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour
{   
    public float TimeOffset;
    public float MoveTimeDelta;
    public float Speed;
    public bool isPaused;

    private float GameTime;
    private float MoveTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        GameTime += Time.deltaTime;

        if(GameTime > TimeOffset)
        {
            MoveTime += Time.deltaTime;

            if(MoveTime > MoveTimeDelta && !isPaused)
            {
                Move();
                MoveTime = 0;
            }
        }

    }

    private void Move()
    {
        transform.position += Vector3.up * Speed * Time.deltaTime;
    }
}
