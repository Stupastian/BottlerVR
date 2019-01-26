using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrabber : MonoBehaviour
{

    public Transform grabObject;
    public bool holding;

    public void GrabActionTake(Transform grabObject)
    {
        //holding = true;
        //if (holding)
        //{
            grabObject.SetParent(this.gameObject.transform);
            grabObject.GetComponent<Collider>().enabled = false;
            if (grabObject.GetComponent<Rigidbody>())
            {
                grabObject.GetComponent<Rigidbody>().isKinematic = true;
                grabObject.GetComponent<Rigidbody>().useGravity = false;

            }
        //}
        Debug.Log("A grab taking action occured");
    }
    public void GrabActionRelease(Transform grabObject)
    {
            if (grabObject.GetComponent<Rigidbody>())
            {
                grabObject.GetComponent<Rigidbody>().isKinematic = false;
                grabObject.GetComponent<Rigidbody>().useGravity = true;
            }
            grabObject.GetComponent<Collider>().enabled = true;
            grabObject.SetParent(null);
            grabObject = null;
            holding = false;
        Debug.Log("A grab release action occured");
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
