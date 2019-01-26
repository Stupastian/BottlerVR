using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrabber : MonoBehaviour
{

    public Transform grabObject;
    public bool holding;

    public void GrabAction(Transform grabObject)
    {
        holding = !holding;
        if (holding)
        {
            grabObject.SetParent(this.gameObject.transform);
            grabObject.GetComponent<Collider>().enabled = false;
            if (grabObject.GetComponent<Rigidbody>())
            {
                grabObject.GetComponent<Rigidbody>().isKinematic = true;
                grabObject.GetComponent<Rigidbody>().useGravity = false;

            }
        }
        else
        {
            if (grabObject.GetComponent<Rigidbody>())
            {
                grabObject.GetComponent<Rigidbody>().isKinematic = false;
                grabObject.GetComponent<Rigidbody>().useGravity = true;
            }
            grabObject.GetComponent<Collider>().enabled = true;
            grabObject.SetParent(null);
            grabObject = null;
        }
        Debug.Log("A grab action occured");
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
