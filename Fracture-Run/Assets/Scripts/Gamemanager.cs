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
