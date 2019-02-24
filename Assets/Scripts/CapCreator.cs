using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapCreator : MonoBehaviour
{
    public GameObject bottleCap;
    public GameObject sombrero;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "bottle")
        {
            GameObject newBottlecap = Instantiate(bottleCap, collision.gameObject.transform.position, collision.gameObject.transform.rotation, collision.gameObject.transform);
            collision.gameObject.tag = "BottleWithCap";
        }
        else if (collision.gameObject.tag == "Manuel")
        {
            GameObject newBottlecap = Instantiate(sombrero, collision.gameObject.transform.position, collision.gameObject.transform.rotation, collision.gameObject.transform);
            collision.gameObject.tag = "ManuelWithSombrero";
        }


    }
    

}
