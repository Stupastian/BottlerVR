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
    public BossMove boss;
    bool musicChanged = false;
    bool victory = false;

    public AudioSource scoreSource;
    public AudioSource musicSource;

    public AudioClip scoreClip;

    public AudioClip musicClip1;
    public AudioClip musicClip2;
    public AudioClip musicClip3;

    public float countDown = 120f; // how long the game runs in seconds

    // Start is called before the first frame update
    void Start()
    {
        winner.SetActive(false);
        loser.SetActive(false);
        scoreSource.clip = scoreClip;
        musicSource.clip = musicClip1;
        musicSource.Play();
    }

    private void Update()
    {
        if (countDown < 30f && musicChanged == false)
        {
            musicSource.Stop();
            musicSource.clip = musicClip2;
            musicSource.Play();
            musicChanged = true;
        }

        if (countDown > 0f && score < winCondition)
        {
            countDown -= Time.deltaTime;
        }

        timeLeft.text = "Vuoroa jäljellä: " + Mathf.RoundToInt(countDown) + " sec";

        if (countDown <= 0f && score < winCondition)
        {
            loser.SetActive(true);
            musicSource.Stop();
        }

        if (Input.GetKeyDown(KeyCode.S)) //This is cheat
        {
            score += 1;
            scoreText.text = "Korkitettu: " + score;
            scoreSource.Play();
            if (score >= winCondition && countDown > 0f && victory == false)
            {
                winner.SetActive(true);
                musicSource.Stop();
                musicSource.clip = musicClip3;
                musicSource.Play();
                victory = true;
            }
            if (score == 3)
            {
                boss.Reset();
                boss.GetComponent<BossMove>().enabled = true;
            }
            if (score == 7)
            {
                boss.Reset();
                boss.GetComponent<BossMove>().enabled = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        UpdateScoreValue(other);
        

        Destroy(other.gameObject);

        CheckWinCondition();
    }

    private void CheckWinCondition()
    {
        if (score >= winCondition && countDown > 0f && victory == false)
        {
            winner.SetActive(true);
            musicSource.Stop();
            musicSource.clip = musicClip3;
            musicSource.Play();
            victory = true;
        }
    }

    private void UpdateScoreValue(Collider other)
    {
        if (other.tag == "BottleWithCap")
        {
            score += 1;
            scoreSource.Play();
        }
        else if (other.tag == "bottle")
        {
            score -= 1;
        }
        else if (other.tag == "ManuelWithSombrero")
        {
            score += 3;
            scoreSource.Play();
        }
        else if (other.tag == "Manuel")
        {
            score -= 5;
        }
        //Update score textvalue visible to player
        scoreText.text = "Korkitettu: " + score;

        if (score == 3)
        {
            boss.Reset();
            boss.GetComponent<BossMove>().enabled = true;
        }
        if (score == 7)
        {
            boss.Reset();
            Debug.Log("ukon toinen käynnistys");
            boss.GetComponent<BossMove>().enabled = true;
        }
    }

    public int getScore()
    {
        return score;
    }
}
