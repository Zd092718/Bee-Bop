using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private float scoreMultiplier;

    public const string HighScoreKey = "HighScore";
    private bool isGameOver = false;
    private float score;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        gameOverScreen.SetActive(false);
    }

    void Update()
    {
        if(isGameOver) { return; }
        score += Time.deltaTime * scoreMultiplier;
        scoreText.text = "Score: " + Mathf.FloorToInt(score).ToString();
    }

    public void GameOver()
    {
        isGameOver = true;

        ObstacleSpawner obstacleSpawner = GameObject.Find("ObstacleSpawner").GetComponent<ObstacleSpawner>();
        obstacleSpawner.StopSpawning();

        gameOverScreen.SetActive(true);
    }

    //public void IncrementScore()
    //{
    //    if (!isGameOver)
    //    {
    //        score ++;

    //        scoreText.text = "Score: " + score.ToString();
    //    }
    //}

    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void StoreHighScore()
    {
        int currentHighScore = PlayerPrefs.GetInt(HighScoreKey, 0);

        if (score > currentHighScore)
        {
            PlayerPrefs.SetInt(HighScoreKey, Mathf.FloorToInt(score));
        }
    }
}
