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
    public bool isGrounded;


    void Start()
    {
        body = GetComponent<Rigidbody>();
    }


    void OnCollisionStay()
    {
        isGrounded = true;
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
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            body.AddForce(Vector3.up * Mathf.Sqrt(JumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
            isGrounded = false;
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
            Vector3 dashVelocity = Vector3.Scale(transform.forward, DashDistance * new Vector3((Mathf.Log( 1f / (Time.deltaTime * body.drag + 1)) / -Time.deltaTime), 0, (Mathf.Log( 1f / (Time.deltaTime * body.drag + 1 )) / -Time.deltaTime)));
            body.AddForce(dashVelocity, ForceMode.VelocityChange);
        }
    }


    void FixedUpdate()
    {
        body.MovePosition(body.position + inputs * Speed * Time.fixedDeltaTime);
    }
}