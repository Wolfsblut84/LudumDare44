﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotController : MonoBehaviour
{
    public GameObject target;

    // Start is called before the first frame update
    public bool isCollected = false;
    private float minDistance = 2f;
    private float maxDistance = 10f;
    private float moveSpeed = 5f;
    private bool doNotCollect = false;
  
    void Start()
    {
        moveSpeed = target.GetComponent<PlayerController>().Speed; 
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name.Contains("Player Capsule"))
        {
           this.isCollected = true;
        }

        if (other.gameObject.name.Contains("Goal"))
        {
            this.isCollected = false;
            this.doNotCollect = true;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (isCollected && doNotCollect == false)
        {
            //this.transform.position = new Vector3(transform.position.x,target.transform.position.y,transform.position.z);

            if (Vector3.Distance(transform.position, target.transform.position) >= minDistance && Vector3.Distance(transform.position, target.transform.position) <= maxDistance)
            {
                //this.transform.position += transform.forward * moveSpeed * Time.deltaTime;
                this.transform.position = Vector3.Lerp(this.transform.position, target.transform.position + new Vector3(0,0.1f,0), moveSpeed * Time.deltaTime);
            }
        }

    }
}
