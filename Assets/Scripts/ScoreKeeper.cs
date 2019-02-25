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

    private void OnCollisionEnter(Collision other)
    {
        UpdateScoreValue(other);
        

        Destroy(other.gameObject);

        CheckWinCondition();
    }

    private void CheckWinCondition()
    {
        if (score >= winCondition && countDown > 0f)
        {
            winner.SetActive(true);
        }
    }

    private void UpdateScoreValue(Collision other)
    {
        if (other.gameObject.tag == "BottleWithCap")
        {
            score += 1;
        }
        else if (other.gameObject.tag == "Bottle")
        {
            score -= 1;
        }
        else if (other.gameObject.tag == "ManuelWithSombrero")
        {
            score += 3;
        }
        else if (other.gameObject.tag == "Manuel")
        {
            score -= 5;
        }
        //Update score textvalue visible to player
        scoreText.text = "Korkitettu: " + score;
    }
}
