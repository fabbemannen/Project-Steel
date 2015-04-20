﻿using UnityEngine;
using System.Collections;

public class BasicVehicleControl : MonoBehaviour 
{

    public float speed = 90.0f;
    public float turnSpeed = 5.0f;
    public float jumpHeight = 20.0f;

    public float maxSpeed = 100.0f;

    public float hoverForce = 65.0f;
    public float hoverHeight = 3.5f;

    private float powerInput;
    private float turnInput;

    private Rigidbody rigidbody;
    private bool isJumping;

	// Use this for initialization
	void Awake () 
    {
        rigidbody = GetComponent<Rigidbody>();
        isJumping = false;
	}

    // Update is called once per frame
    void Update()
    {
        VehicleInput();
        
        if(Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    void FixedUpdate()
    {
        Vector3 vel = rigidbody.velocity;
        if (vel.magnitude > maxSpeed)
        {
            vel.Normalize();
            vel *= maxSpeed;
            rigidbody.velocity = vel;
        }
    }

    void VehicleInput()
    {
        float moveDistance = speed * Time.deltaTime;

        if (Input.GetKeyDown("space"))
        {
            rigidbody.velocity += transform.up * jumpHeight * Time.deltaTime;

            if (!isJumping)
            {                
                isJumping = true;
            }            
        }

        if (Input.GetKey("w"))
        {
            transform.Translate(Vector3.forward * moveDistance);

            //rigidbody.velocity += transform.forward * moveDistance;
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(-Vector3.forward * moveDistance);

            //rigidbody.velocity += -transform.forward * moveDistance;
        }

        if (Input.GetKey("a"))
        {
            Vector3 rotVector = new Vector3(0.0f, -turnSpeed, 0.0f);
            transform.Rotate(rotVector * Time.deltaTime);
        }
        if (Input.GetKey("d"))
        {
            Vector3 rotVector = new Vector3(0.0f, turnSpeed, 0.0f);
            transform.Rotate(rotVector * Time.deltaTime);
        }

        if (Input.GetKey("right"))
        {
            Vector3 rotVector = new Vector3(0.0f, 0.0f, -turnSpeed);
            transform.Rotate(rotVector * Time.deltaTime);
        }

        if (Input.GetKey("left"))
        {
            Vector3 rotVector = new Vector3(0.0f, 0.0f, turnSpeed);
            transform.Rotate(rotVector * Time.deltaTime);
        }
    }  
      
}


// alt. input

/*


// Update is called once per frame
    void Update () 
    {
        powerInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");
    }
    
    void FixedUpdate()
    {
        rigidbody.AddRelativeForce(0.0f, 0.0f, powerInput * speed);
        rigidbody.AddRelativeTorque(0.0f, turnInput * speed, 0.0f);
    }


*/

// alt.2 input

/*

 // Update is called once per frame
    void Update () 
    {
        VehicleInput();
    }
    
    void VehicleInput()
    {
                float moveDistance = speed * Time.deltaTime;

        if (Input.GetKeyDown("space"))
        {
            rigidbody.velocity += transform.up * jumpHeight * Time.deltaTime;
        }

        if (Input.GetKey("w"))
        {
            transform.Translate(Vector3.forward * moveDistance);
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(-Vector3.forward * moveDistance);
        }

        if (Input.GetKey("a"))
        {
            Vector3 rotVector = new Vector3(0.0f, -turnSpeed, 0.0f);
            transform.Rotate(rotVector * Time.deltaTime);
        }
        if (Input.GetKey("d"))
        {
            Vector3 rotVector = new Vector3(0.0f, turnSpeed, 0.0f);
            transform.Rotate(rotVector * Time.deltaTime);
        }

        if (Input.GetKey("right"))
        {
            Vector3 rotVector = new Vector3(0.0f, 0.0f, -turnSpeed);
            transform.Rotate(rotVector * Time.deltaTime);
        }

        if (Input.GetKey("left"))
        {
            Vector3 rotVector = new Vector3(0.0f, 0.0f, turnSpeed);
            transform.Rotate(rotVector * Time.deltaTime);
        }
  }

*/