using JetBrains.Annotations;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance;
    public bool gameStarted;

    public GameObject platformSpawner;  
    public GameObject scoreUi;
    public GameObject MenuUI;

    public Text scoreText;
    public Text highScoreText;


    public int score = 0;
    int highScore ;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        Application.targetFrameRate = 60;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
        highScoreText.text = "Best Score : " + highScore;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!gameStarted)
            {
                GameStart();
            }

        }     
    }

    public void GameStart()
    {
        gameStarted = true;

        platformSpawner.SetActive(true);

        scoreUi.SetActive(true);
        MenuUI.SetActive(false);


        StartCoroutine(UpdateScore());



    }
     public void GameOver()
    {
        platformSpawner.SetActive(false);
        SaveHighScore();
        StopAllCoroutines();
        Invoke("Reload", 2f);

    }

    void Reload()
    {
        SceneManager.LoadScene("Game");
        
    }

    IEnumerator UpdateScore()
    {
        while (true)
        {

            yield return new WaitForSeconds(1f);
            score++;
            scoreText.text = score.ToString();
        }
        

    }

    void SaveHighScore()
    {
        int savedHighScore = PlayerPrefs.GetInt("HighScore", 0);

        if (score > savedHighScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
            PlayerPrefs.Save();
        }
    }
}
