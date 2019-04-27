using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody rb;
    public bool isGrounded;
    public float maxJumpHeight = 2f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");
        float jump = Input.GetAxis("Jump");

        //rb.mass = 1;



        Vector3 movement = new Vector3(moveHorizontal, jump, 0);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(movement * speed, ForceMode.Impulse);
            isGrounded = false;

        }
    }

}
