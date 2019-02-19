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
    public Text timeLeft;

    public float countDown = 120f; // how long the game runs in seconds

    // Start is called before the first frame update
    void Start()
    {
        winner.SetActive(false);
        loser.SetActive(false);
    }

    private void Update()
    {
        if (countDown > 0f && score < winCondition)
        {
            countDown -= Time.deltaTime;
        }

        timeLeft.text = "Vuoroa jäljellä: " + Mathf.RoundToInt(countDown) + " sec";

        if (countDown <= 0f && score < winCondition)
        {
            loser.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.S)) //This is cheat
        {
            score += 1;
            scoreText.text = "Korkitettu: " + score;
            if (score >= winCondition && countDown > 0f)
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
            if (score >= winCondition && countDown > 0f)
            {
                winner.SetActive(true);
            }
            Destroy(other.gameObject);
        }
    }

}
