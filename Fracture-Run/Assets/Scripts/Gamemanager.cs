using JetBrains.Annotations;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance;
    public bool gameStarted;

    public GameObject platformSpawner;

    public TextMeshProUGUI scoreText;
    int score = 0;
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
        StartCoroutine(UpdateScore());



    }
     public void GameOver()
    {
        platformSpawner.SetActive(false);
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

}
