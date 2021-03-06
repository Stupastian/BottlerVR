﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrabber : MonoBehaviour
{
    public bool holding;
    private Rigidbody rigidBody;

    public void GrabActionTake(Transform grabObject)
    {
        holding = true;
        rigidBody = grabObject.GetComponent<Rigidbody>();

        grabObject.SetParent(this.gameObject.transform);
            if (rigidBody)
            {
                rigidBody.isKinematic = true;
                rigidBody.useGravity = false;
                rigidBody.constraints = RigidbodyConstraints.FreezeAll;
        }
        
    }
    public void GrabActionRelease(Transform grabObject)
    {
        
        rigidBody = grabObject.GetComponent<Rigidbody>();
            if (rigidBody)
            {
                rigidBody.isKinematic = false;
                rigidBody.useGravity = true;
                rigidBody.constraints = RigidbodyConstraints.None;
        }
        grabObject.SetParent(null);
        holding = false;
        Debug.Log("A grab release action occured");
    }

    public void GrabActionThrow(Transform grabObject, Vector3 velocity)
    {
        rigidBody = grabObject.GetComponent<Rigidbody>();
        rigidBody.velocity = velocity * 100;
        grabObject = null;

        //Debug.Log("A throw action occured");
        //Debug.Log("RigidBody Velocity: " + rigidBody.velocity);
    }

    void Update()
    {
        Debug.Log("Holding: " + holding);
    }

    }
