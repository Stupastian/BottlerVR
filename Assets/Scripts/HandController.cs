using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandController : MonoBehaviour
{
    public XRNode Controller;
    public Transform grabObject;
    private string grabButton;
    public ObjectGrabber og;

    public void CreateCandidate(Transform candidate)
    {
        grabObject = candidate;
    }

    // Start is called before the first frame update
    void Start() {
        if (Controller == XRNode.LeftHand)   {
            grabButton = "Fire1";
        }
            if (Controller == XRNode.RightHand)  {
                grabButton = "Fire1";
            }

        }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = InputTracking.GetLocalPosition(Controller);
        transform.localRotation = InputTracking.GetLocalRotation(Controller);

        if (grabObject != null && Input.GetButton(grabButton))   {
            og.GrabAction(grabObject);
        }
        if (og.holding == false)
        {
            grabObject = null;
        }
    }
}
