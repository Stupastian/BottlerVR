using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandAnimation : MonoBehaviour
{
    public GameObject hand;
    Animator handAnimator;
    ObjectGrabber grabber;
    public XRNode Controller;
    private string grabButtonRight;
    // Start is called before the first frame update
    void Start()
    {
        handAnimator = GetComponentInChildren<Animator>();
        grabber = hand.GetComponent<ObjectGrabber>();

        if (Controller == XRNode.RightHand)
        {
            grabButtonRight = "Fire3";
            Debug.Log("Right Controller Activated:");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton(grabButtonRight))
        {
            if (!handAnimator.GetBool("IsGrabbing"))
            {
                Debug.Log("Animate Grab");
                handAnimator.SetBool("IsGrabbing", true);
            }
        }
        else
        {
            if (handAnimator.GetBool("IsGrabbing"))
            {
                Debug.Log("Stop Grab animation");
                handAnimator.SetBool("IsGrabbing", false);
            }
        }
    }
}
