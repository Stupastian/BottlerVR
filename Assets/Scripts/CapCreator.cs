using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapCreator : MonoBehaviour
{

    public GameObject bottleCap;
    public Vector3 capPosition;
    public Quaternion capRotation;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "bottle")
        {
            //TODO create a bottle cap and attach it to the bottle that collided
            //Instantiate(bottleCap, collision.gameObject.transform);
            //bottleCap.transform.parent = collision.gameObject.transform;
            //bottleCap.transform.localPosition = bottleCap.transform.parent.localPosition;
            //bottleCap.transform.localEulerAngles = bottleCap.transform.parent.localRotation;
        }
    }

}
