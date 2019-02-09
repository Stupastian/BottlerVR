using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public GameObject belt;
    public Transform endpoint;
    Renderer renderere;
    [SerializeField] public float speed = 1f;
    [SerializeField] public bool beltRunning = true;
    [SerializeField] public float testvalue = 1.42f;

    private void Start()
    {
        renderere = GetComponent<Renderer>();    
    }

    private void Update()
    {
        //Sync with bottle velocity if speed is adjusted
        float realValue = testvalue * speed * Time.deltaTime;
        
        Vector2 old = renderere.material.GetTextureOffset("_MainTex");
        renderere.material.SetTextureOffset("_MainTex", old + new Vector2(0, realValue));

    }

    public void OnCollisionStay(Collision collision)
    {
        float beltVelocity = speed * Time.deltaTime;
        collision.transform.position = Vector3.MoveTowards(collision.transform.position, endpoint.position, speed * Time.deltaTime);
    }
    //public void OnCollisionExit(Collision collision)
    //{
    //    Debug.Log("No more collision" + collision.collider.name);
    //}

}
