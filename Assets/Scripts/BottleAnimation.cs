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
    public AudioSource manuelSource;
    public AudioClip manuelClip;
    bool isPlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        bottleAnimator = GetComponentInChildren<Animator>();
        manuelSource.clip = manuelClip;
    }

    private void Update()
    {
        triggerDistance = Vector3.Distance(player.transform.position, target.transform.position);
        Debug.Log("trggerDistance = " +triggerDistance);
        Debug.Log("animator bool: " +bottleAnimator.GetBool("PlayerTooClose"));
        if (triggerDistance < triggerActivationDistance)
        {
            bottleAnimator.SetBool("PlayerTooClose", true);
            if (isPlaying == false)
            {
                manuelSource.Play();
                isPlaying = true;
            }
        }
        if (triggerDistance > triggerDeActiovationDistance)
        {
            bottleAnimator.SetBool("PlayerTooClose", false);
            if (isPlaying == true)
            {
                manuelSource.Stop();
                isPlaying = false;
            }
        }

    }
}


