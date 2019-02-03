using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapCreator : MonoBehaviour
{
    public GameObject bottleCap;

    private void OnTriggerEnter(Collision collision)
    {
        if(collision.gameObject.tag == "bottle")
        {
            GameObject newBottlecap = Instantiate(bottleCap, collision.gameObject.transform.position, collision.gameObject.transform.rotation, collision.gameObject.transform);
            collision.gameObject.tag = "BottleWithCap";
        }
    }
    

}
