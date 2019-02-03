using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandController : MonoBehaviour
{
    public XRNode Controller;
    public Transform grabObject;
    private string grabButtonRight;
    private string grabButtonLeft;
    public ObjectGrabber og;
    //public Quaternion controllerRotation;
    private Vector3 ControllerPosition1;
    private Vector3 ControllerPosition2;
    private Vector3 ControllerVelocity;
    private bool pressed = false;
    private bool velocity;

    public void CreateCandidate(Transform candidate)
    {
        grabObject = candidate;
        Debug.Log("A grab object candidate");
    }

    // Start is called before the first frame update
    void Start()
    {
        if (Controller == XRNode.LeftHand)
        {
            grabButtonLeft = "Fire2";
            Debug.Log("Left Controller Activated:");
        }
        if (Controller == XRNode.RightHand)
        {
            grabButtonRight = "Fire3";
            Debug.Log("Right Controller Activated:");
        }

    }

    // Update is called once per frame
    void Update()
    {
        //Following the controllers in scene
        transform.localPosition = InputTracking.GetLocalPosition(Controller);
        transform.localRotation = InputTracking.GetLocalRotation(Controller);
        
        //For calculating velocity for throwing we need the location of the controller
        //controllerRotation = InputTracking.GetLocalRotation(Controller);
        ControllerPosition2 = ControllerPosition1;
        ControllerPosition1 = InputTracking.GetLocalPosition(Controller);
        ControllerVelocity = ControllerPosition1 - ControllerPosition2;
        Debug.Log("Controller Velocity: " + ControllerVelocity);

        //For grabbing object we need to have an object and the right button (depending on the controller)
        if (grabObject != null && ((Controller == XRNode.RightHand && Input.GetButton(grabButtonRight)) || (Controller == XRNode.LeftHand && Input.GetButton(grabButtonLeft))))
        {
            og.GrabActionTake(grabObject);
            pressed = true;
        }
        //For releasing the object and throwing it we need to have an object and release the appropriate button
        if (pressed && grabObject != null && ((Controller == XRNode.RightHand && !Input.GetButton(grabButtonRight)) || (Controller == XRNode.LeftHand && !Input.GetButton(grabButtonLeft))))
        {
            og.GrabActionRelease(grabObject);
            og.GrabActionThrow(grabObject, ControllerVelocity);
            grabObject = null;
            pressed = false;
        }
    }
}
