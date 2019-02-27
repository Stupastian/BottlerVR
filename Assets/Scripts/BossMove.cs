using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour

{

    public float speed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        //transform.Rotate
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, speed, 0);
        transform.position += transform.forward * Time.deltaTime;
    }

}
