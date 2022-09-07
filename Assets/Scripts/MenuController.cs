using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour
{
    [SerializeField] TMP_Text highScoreText;

    private void Start()
    {

        int highScore = PlayerPrefs.GetInt(GameManager.HighScoreKey, 0);
        highScoreText.text = $"High Score: {highScore}";
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
