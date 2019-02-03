using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapCreator : MonoBehaviour
{
    public GameObject bottleCap;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "bottle")
        {
            GameObject newBottlecap = Instantiate(bottleCap, collision.gameObject.transform.position, collision.gameObject.transform.rotation, collision.gameObject.transform);
            newBottlecap.gameObject.tag = "BottleWithCap";
            // Tähän tarvittaisiin vielä jotain miten saataisiin siitä itse pullostakin tägi tuoksi, koska nyt tägi on pullossa Untagged ja korkissa tuo BottleWithCap
        }
    }
    

}
