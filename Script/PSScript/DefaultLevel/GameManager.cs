using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public delegate void GameDelegate();
    public static event GameDelegate OnGameStarted;
    public static event GameDelegate OnGameOverConfirmed;

    public static GameManager Instance; 

    public GameObject startPage;
    public GameObject gameOverPage;
    public GameObject countdownPage;
    public GameObject TextScore;
    public Text scoreText;

    enum PageState
    {
        None,
        Start,
        GameOver,
        Countdown
    }

    int score = 0;
    public static int scoreForShow = 0;
    bool gameOver = true;

    public bool GameOver { get { return gameOver; } }
    public int Score { get { return score; } }

    void Awake() {
        Instance = this;
    }
    void OnEnable(){
        CountdownText.OnCountdownFinished += OnCountdownFinished;
        TapControllet.OnPlayerDied += OnPlayerDied;
        TapControllet.OnPlayerScored += OnPlayerScored;
    }

    void OnDisable() {
        CountdownText.OnCountdownFinished -= OnCountdownFinished;
        TapControllet.OnPlayerDied -= OnPlayerDied;
        TapControllet.OnPlayerScored -= OnPlayerScored;
    }

    void OnCountdownFinished(){
        SetPageState(PageState.None);
        OnGameStarted(); // event sent TapController
        score = 0;
        gameOver = false;
    }

    void OnPlayerDied(){
        gameOver = true;
        int saveScore = PlayerPrefs.GetInt("HighScore");
        if (score > saveScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
        SetPageState(PageState.GameOver);
    }

    void OnPlayerScored(){
        score++;
        scoreForShow = score;
        scoreText.text = score.ToString();
    }

    void SetPageState(PageState state){
        switch (state){
            case PageState.None:
                startPage.SetActive(false);
                gameOverPage.SetActive(false);
                countdownPage.SetActive(false);
                TextScore.SetActive(true);
                break;
            case PageState.Start:
                startPage.SetActive(true);
                gameOverPage.SetActive(false);
                countdownPage.SetActive(false);
                TextScore.SetActive(false);
                break;
            case PageState.GameOver:
                startPage.SetActive(false);
                gameOverPage.SetActive(true);
                countdownPage.SetActive(false);
                TextScore.SetActive(false);
                break;
            case PageState.Countdown:
                startPage.SetActive(false);
                gameOverPage.SetActive(false);
                countdownPage.SetActive(true);
                TextScore.SetActive(false);
                break;
        }
    }

    public void ConfirmGameOver(){
        //activated when replay button is hit
        OnGameOverConfirmed();//event
        scoreText.text = "0";
        SetPageState(PageState.Start);
    }
    public void StartGame(){
        //activated when play button is hit
        SetPageState(PageState.Countdown);
    }
}
