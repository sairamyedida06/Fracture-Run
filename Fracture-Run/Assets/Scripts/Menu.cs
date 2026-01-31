using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    // Drag your High Score Text UI object here in the Inspector
    public Text highScoreText;

    void Start()
    {  
        int savedScore = PlayerPrefs.GetInt("HighScore", 0);


        highScoreText.text = "Best Score: " + savedScore;

    }

    public void Play()
    {
        SceneManager.LoadScene("Game");
    }
    public void Quit()
    {
        Application.Quit();
    }

   
}