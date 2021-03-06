﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    // Attribute
    public float Speed = 5f;
    public float JumpHeight = 2f;
    public float GroundDistance = 0.2f;
    public float DashDistance = 5f;
    public LayerMask Ground;
    private Rigidbody body;
    private Vector3 inputs = Vector3.zero;
    public int isGrounded;
    public GameObject explosion;


    public int playerHealth;

    public GameObject gameOver;

    AudioSource[] audioSources;


    void Start()
    {
        body = GetComponent<Rigidbody>();
        audioSources = GetComponents<AudioSource>();
        if (playerHealth >= 0 && this.transform.position.y > 0)
        {
            gameOver.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "WaterCube")
        {
            playerHealth = 0;
        }

        isGrounded = 0;
        

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Enemy Cylinder"))
        {
            playerHealth -= 1;
        }
    }


    private void OnCollisionStay()
    {
    }

    private void OnDestroy()
    {
    }

    void Update()
    {
        // Input Achsen
        inputs = Vector3.zero;
        inputs.x = Input.GetAxis("Horizontal");
        inputs.z = Input.GetAxis("Vertical");


        if (inputs != Vector3.zero)
        {
            transform.forward = inputs;
        }

        // Key Press Springen
        if (Input.GetButtonDown("Jump") && isGrounded < 2)
        {
            body.AddForce(Vector3.up * Mathf.Sqrt(JumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
            isGrounded++;
            audioSources[0].Play();
        }

        // Key press Rennen
        if (Input.GetButtonDown("Shift"))
        {
            this.Speed = 10;
        }

        // Key loslassen Rennen
        if (Input.GetButtonUp("Shift"))
        {
            this.Speed = 5;
        }

        // Laufen  allgemein
        if (Input.GetButtonDown("Dash"))
        {
            Vector3 dashVelocity = Vector3.Scale(transform.forward, DashDistance * new Vector3((Mathf.Log(1f / (Time.deltaTime * body.drag + 1)) / -Time.deltaTime), 0, (Mathf.Log(1f / (Time.deltaTime * body.drag + 1)) / -Time.deltaTime)));
            body.AddForce(dashVelocity, ForceMode.VelocityChange);
        }

        // GameOver 
        if (playerHealth <= 0 || this.transform.position.y < 0)
        {
            // Player Tot
            Explode();

        }

    }

    private void Explode()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        if (gameOver != null)
        {
            gameOver.SetActive(true);
            //this.GetComponent<GameMasterController>().Menu.SetActive(true);
            //this.GetComponent<GameMasterController>().startGame = false;

        }
        Destroy(this.gameObject);
    }

    void FixedUpdate()
    {
        body.MovePosition(body.position + inputs * Speed * Time.fixedDeltaTime);
    }
}