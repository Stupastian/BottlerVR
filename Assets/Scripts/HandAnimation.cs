using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAnimation : MonoBehaviour
{

    Animator handAnimator;
    [SerializeField] ObjectGrabber grabber;
    // Start is called before the first frame update
    void Start()
    {
        handAnimator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (grabber.holding)
        {
            if (handAnimator.GetBool("IsGrabbing"))
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
