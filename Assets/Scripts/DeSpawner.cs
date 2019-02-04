using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DeSpawner : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "bottle" || collision.gameObject.tag == "BottleWithCap")
        {
            Destroy(collision.gameObject);
        }
    }

}

