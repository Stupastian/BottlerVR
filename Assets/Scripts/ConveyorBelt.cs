using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public GameObject belt;
    public Transform endpoint;
    [SerializeField] public float speed = 10;
    [SerializeField] public bool beltRunning = true;


    public void OnCollisionStay(Collision collision)
    {
        float beltVelocity = speed * Time.deltaTime;
        collision.transform.position = Vector3.MoveTowards(collision.transform.position, endpoint.position, speed * Time.deltaTime);
    }

}
