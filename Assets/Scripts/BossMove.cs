using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour

{

    public AudioSource bossSource;
    public AudioClip bossClip;
    public float speed = 3f;
    public float countDown1 = 7f;// how long the game boss walks in seconds
    public float countDown2 = 7f;
    public bool turned = false;
    public bool done = false;


    public Animator anim;

    public void Reset()
    {
        countDown1 = 7f;// how long the game boss walks in seconds
        countDown2 = 7f;
        turned = false;
        done = false;
        anim = GetComponent<Animator>();
        anim.Play("Walk_Blocking");
        BossTurn(90);
        bossSource.clip = bossClip;
        bossSource.Play();

    }

    // Update is called once per frame
    void Update()
    {

        if (countDown1 > 0f )
        {
            countDown1 -= Time.deltaTime;
            Debug.Log("Aika kävelylle: " + countDown1);
            transform.position += transform.forward * Time.deltaTime;
        }
        if(countDown1 <= 0 && turned == false)
        {
            BossTurn(180);
            turned = true;
        }
        if (countDown2 > 0f && turned == true)
        {
            countDown2 -= Time.deltaTime;
            Debug.Log("Aika kävelylle 2: " + countDown2);
            transform.position += transform.forward * Time.deltaTime;
        }

        if (countDown2 <= 0 && done == false)
        {
            BossTurn(90);
            done = true;
            anim.Play("New State");
            GetComponent<BossMove>().enabled = false;
        }
    }

    void BossTurn(int degrees)
    {
        transform.Rotate(transform.rotation.x, transform.rotation.y + degrees, transform.rotation.z);
        
    }

}
