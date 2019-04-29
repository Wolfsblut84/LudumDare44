using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterController : MonoBehaviour
{   
    public float TimeOffset;
    public float MoveTimeDelta;
    public float Speed;
    public bool isPaused;

    public Text timerText;

    private float GameTime;
    private float MoveTime;

    // Start is called before the first frame update
    void Start()
    {
        string minSec = string.Format("{0}:{1:00}", (int)TimeOffset / 60, (int)TimeOffset % 60);
        timerText.text = minSec;
    }
    
    // Update is called once per frame
    void Update()
    {
        GameTime += Time.deltaTime;

        if(GameTime > TimeOffset)
        {
            string minSec = string.Format("{0}:{1:00}", (int)(GameTime-TimeOffset) / 60, (int)(GameTime-TimeOffset) % 60);
            timerText.text = minSec;
            MoveTime += Time.deltaTime;

            if(MoveTime > MoveTimeDelta && !isPaused)
            {
                Move();
                MoveTime = 0;
            }
        }
        else
        {
            string minSec = string.Format("{0}:{1:00}", (int)(TimeOffset - GameTime) / 60, (int)(TimeOffset - GameTime) % 60);
            timerText.text = minSec;
        }


    }

    private void Move()
    {
        transform.position += Vector3.up * Speed * Time.deltaTime;
    }
}
