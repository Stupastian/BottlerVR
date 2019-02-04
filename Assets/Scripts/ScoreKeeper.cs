using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{

    public int score = 0;
    public int winCondition = 10;
    public GameObject winner;
    public GameObject loser;
    public Text scoreText;

    public float countDown = 1000f; // how long the game runs in seconds

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        countDown -= Time.deltaTime;
        if (countDown <= 0f && score < winCondition)
        {
            loser.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.S)) //This is cheat
        {
            score += 1;
            scoreText.text = "Score: " + score;
            if (score >= winCondition)
            {
                winner.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BottleWithCap")
        {
            score += 1;
            scoreText.text = "Score: " + score;
            if (score >= winCondition)
            {
                winner.SetActive(true);
            }
            Destroy(other.gameObject);
        }
    }

}
