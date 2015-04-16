﻿using UnityEngine;
using System.Collections;

public class BasicGravity : MonoBehaviour 
{

    public float gravitationalAcceleration = 9.81f;
    public Transform gravityObject;
    
    private Rigidbody rigidbody;
    private bool sideRoad = false;


	// Use this for initialization
	void Start () 
    {
        rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (gravityObject == null)
        {
            rigidbody.useGravity = true;
        }
        else
        {
            rigidbody.useGravity = false;

            CustomGravity();
        }        
	}
        
    void CustomGravity()
    {
        Vector3 accel = gravitationalAcceleration * Time.deltaTime * (gravityObject.position - transform.position);

        if (sideRoad)
        {
            accel.y = 0;
            accel.z = 0;
        }
        else
        {
            accel.x = 0;
            accel.z = 0;
        }
        
        rigidbody.velocity += accel;
    }

    public void SetGravityObject(Transform a_transform, bool a_sideroad)
    {
        gravityObject = a_transform;
        sideRoad = a_sideroad;
    }

    public void ClearGravityObject()
    {
        gravityObject = null;
    }
}