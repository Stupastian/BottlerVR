using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltSpeedAdjuster : MonoBehaviour
{

    public GameObject speedController;
    public GameObject adjustmentTarget;

    private void OnTriggerEnter(Collider other)
    {
        //if(speedController.transform.localRotation > speedController.GetComponent<HingeJoint>().limits.min)
        adjustmentTarget.GetComponent<ConveyorBelt>().speed += .5f;
        Debug.Log("Speed increased!");
    }

}
