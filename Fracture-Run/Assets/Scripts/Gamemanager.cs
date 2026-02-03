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
    public GameObject RetryMenu;
    

    public Text scoreText;

    [Header("Speed Scaling")]
    public int scoreStep = 50;
    public float speedIncreaseAmount = 0.3f;
    public float maxSpeed = 10f;

    private int nextSpeedScore;


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
        
        GameStart();
        nextSpeedScore = scoreStep;

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void GameStart()
    {
        gameStarted = true;

        platformSpawner.SetActive(true);

        scoreUi.SetActive(true);
       


        StartCoroutine(UpdateScore());
    }
     public void GameOver()
    {
        platformSpawner.SetActive(false);
        SaveHighScore();
        StopAllCoroutines();
        Invoke("Reload", 1f);

    }

    public void Reload()
    {
        RetryMenu.SetActive(true);  
    }

    public void Restrat()
    {
        SceneManager.LoadScene("Game");
    }

    IEnumerator UpdateScore()
    {
        while (true)
        {

            yield return new WaitForSeconds(1f);
            score++;
            CheckSpeedIncrease();
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
    void CheckSpeedIncrease()
    {
        if (score >= nextSpeedScore)
        {
            PlayerController.Instance.currentMoveSpeed += speedIncreaseAmount;
            PlayerController.Instance.currentMoveSpeed = Mathf.Min(PlayerController.Instance.currentMoveSpeed, maxSpeed);
            nextSpeedScore += scoreStep;
        }
    }
}
