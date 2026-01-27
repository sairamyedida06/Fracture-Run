using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance;
    public bool gameStarted;

    public GameObject platformSpawner;
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



    }
     public void GameOver()
    {
        platformSpawner.SetActive(false);
        

    }

    
   
}
