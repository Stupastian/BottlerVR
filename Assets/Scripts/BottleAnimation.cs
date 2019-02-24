using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleAnimation : MonoBehaviour
{
    Animator bottleAnimator;
    float triggerDistance;
    public GameObject player;
    public GameObject target;
    public float triggerActivationDistance;
    public float triggerDeActiovationDistance;
    // Start is called before the first frame update
    void Start()
    {
        bottleAnimator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        triggerDistance = Vector3.Distance(player.transform.position, target.transform.position);
        Debug.Log("trggerDistance = " +triggerDistance);
        Debug.Log("animator bool: " +bottleAnimator.GetBool("PlayerTooClose"));
        if (triggerDistance < triggerActivationDistance)
        {
            bottleAnimator.SetBool("PlayerTooClose", true);
        }
        if (triggerDistance > triggerDeActiovationDistance)
        {
            bottleAnimator.SetBool("PlayerTooClose", false);
        }

    }
}


