using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager2 : MonoBehaviour
{
    enum PlayState
    {
        None,
        Countdown,
        Play,
        GameOver,
        Option
    }
    public Text ScoreText;
    public TMP_Text countdownText;
    public TMP_Text HighScoreText;
    public TMP_Text HighScoreText1;
    public TMP_Text ScoreText1;
    public static int Score = 0;
    public static int EnemyScore = 0;
    public AudioHandeler audioHandeler;
    public Player2 Player;
    
    public Shooting2 shootObj;


    // --------------------------------***********      Button programming         ************--------------------------------//
    public void PlayGame() // PlayGame
    {
        StartPageState(PlayState.Countdown);
        PlayButtonAudio();
    }
    public void OptionGame() // Push Game
    {
        StartPageState(PlayState.Option);
        PlayButtonAudio();
    }
    public void ResumeGame() // Resume Game
    {
        StartPageState(PlayState.Play);
        PlayButtonAudio();
    }
    public void Re_StartGame() // ReStart Game
    {
        StartPageState(PlayState.None);
        PlayButtonAudio();
        //SceneManager.LoadScene(5);
    }
// --------------------------------***********      END Button programming         ************--------------------------------//
  
    void Start()
    {
        ///Describe
        HighScoreText.text = PlayerPrefs.GetInt("ScoreLevel2").ToString();
        StartPageState(PlayState.None);
    }
    void Update()
    {
        VisualAllThingsFun();
        if (Player.GameOver)
        {
            SaveGame();
            StartPageState(PlayState.GameOver);
        }
        
    }
    private void VisualAllThingsFun()
    {
        ScoreText.text = "" + Score;
    }
    private void SaveGame()
    {
        
        if (PlayerPrefs.GetInt("ScoreLevel2") < Score)
        {
            PlayerPrefs.SetInt("ScoreLevel2", Score);
        }
        if (PlayerPrefs.GetInt("EnemyScoreLevel2") < EnemyScore)
        {
            PlayerPrefs.SetInt("EnemyScoreLevel2", EnemyScore);
        }
    }

    // --------------------------------***********      GameManager programming         ************--------------------------------//
    // Game Object for Playing Scene
    public GameObject PlayObject;
    public GameObject CoundDownObjrct;
    public GameObject BackgroundObjrct;
    public GameObject GameOverObjrct;
    public GameObject OptionObject; // optional
    public GameObject Envirment;// ptional but MostUsed Program
    
    public GameObject ClearAll;

    // cound Down Text
    private void StartPageState(PlayState state)
    {
        // Play Menu
        // Option Menu
        // Restart Menu
        switch (state){
            case PlayState.None: // Playing The Game Attand First
                PlayObject.SetActive(true);
                CoundDownObjrct.SetActive(false);
                BackgroundObjrct.SetActive(false);
                GameOverObjrct.SetActive(false);
                OptionObject.SetActive(false);
                Envirment.SetActive(false);

                ClearAll.SetActive(false);
                PlayNoneStateFun();
                break;
            case PlayState.Countdown: // Playing The Game Attand Second 
                PlayObject.SetActive(false);
                CoundDownObjrct.SetActive(true);
                BackgroundObjrct.SetActive(false);
                GameOverObjrct.SetActive(false);
                OptionObject.SetActive(false);
                Envirment.SetActive(false);
                PlayCounddownStateFun();
                break;
            case PlayState.Play: // Playing The Game Attand Three 
                PlayObject.SetActive(false);
                CoundDownObjrct.SetActive(false);
                BackgroundObjrct.SetActive(true);
                GameOverObjrct.SetActive(false);
                OptionObject.SetActive(false);
                Envirment.SetActive(true);
                Time.timeScale = 1f;
                //PlayPlayStateFun();
                break;
            case PlayState.GameOver: // Playing The Game Attand Four 
                PlayObject.SetActive(false);
                CoundDownObjrct.SetActive(false);
                BackgroundObjrct.SetActive(false);
                GameOverObjrct.SetActive(true);
                OptionObject.SetActive(false);
                Envirment.SetActive(false);

                ClearAll.SetActive(true);
                GameOverFun();
                break;
            case PlayState.Option: // Optional
                PlayObject.SetActive(false);
                CoundDownObjrct.SetActive(false);
                BackgroundObjrct.SetActive(false);
                GameOverObjrct.SetActive(false);
                OptionObject.SetActive(true);
                Envirment.SetActive(false);
                Time.timeScale = 0.0f;
                //PlayOptionStateFun();
                break;
        }
    }
    private void PlayNoneStateFun()
    {
        Score = 0;
        shootObj.UpDateValue();
        Player.UpDateValue();
    }
    // Coundown Start
    private void PlayCounddownStateFun()
    {
        countdownText.text ="3";
        StartCoroutine("Countdown");
    }
    IEnumerator Countdown(){
        int count = 0;
        for (int i = 3; i >= count; i--)
        {
            countdownText.text = "" + i;
            AudioManager.Instance.PlaySFX(audioHandeler.musicButton);
            yield return new WaitForSeconds(1f);
        }

        StartPageState(PlayState.Play);
    }
    // Coundown End
    private void GameOverFun()
    {
        HighScoreText1.text = PlayerPrefs.GetInt("ScoreLevel2").ToString();
        //HighScoreText1.text = PlayerPrefs.GetInt("EnemyScoreLevel2").ToString();
        ScoreText1.text  = Score.ToString();
        Player.GameOver = false;
    }
    private void PlayButtonAudio()
    {
        AudioManager.Instance.PlaySFX(audioHandeler.musicButton);
    }
    // --------------------------------***********      END GameManager programming         ************--------------------------------//

// Speed the game//
    private void SpeedUpGameFun()
    {
        StartCoroutine("SpeedUp");
    }
    IEnumerator SpeedUp()
    {
        int n = 2;
        float time = 1f;
        for (int i = 0; i < n; i++)
        {
           yield return new WaitForSeconds(60f); 
           time += 0.2f;
           Time.timeScale = time;
           n++;
        }
        
    }
}
