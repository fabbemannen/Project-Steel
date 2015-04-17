﻿using UnityEngine;
using System.Collections;

public class SecondRoadScript : MonoBehaviour 
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<BasicGravity>().SetGravityObjectV2(this.transform, -this.transform.up);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<BasicGravity>().ClearGravityObject();
        }
    }
}
