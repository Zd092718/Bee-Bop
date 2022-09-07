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

    private bool isGameOver = false;
    private int score = 0;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        gameOverScreen.SetActive(false);
    }

    public void GameOver()
    {
        isGameOver = true;

        ObstacleSpawner obstacleSpawner = GameObject.Find("ObstacleSpawner").GetComponent<ObstacleSpawner>();
        obstacleSpawner.StopSpawning();

        gameOverScreen.SetActive(true);
    }

    public void IncrementScore()
    {
        if (!isGameOver)
        {
            score ++;

            scoreText.text = "Score: " + score.ToString();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
