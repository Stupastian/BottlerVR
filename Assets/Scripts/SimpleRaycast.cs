using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SimpleRaycast : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        // Rayn pituus eli ns. reach on tuo viimeinen numero 0.1f eli 0.1 metriä
        if (Physics.Raycast(this.gameObject.transform.position, this.gameObject.transform.TransformDirection(Vector3.forward), out hit, 100f))
        {
            Debug.DrawRay(this.gameObject.transform.position, this.gameObject.transform.TransformDirection(Vector3.forward) * 50, Color.green);
            Debug.Log("Found an object named " + hit.transform.gameObject.name);
            ExecuteEvents.Execute(hit.transform.gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerEnterHandler);
        }
    }
}
