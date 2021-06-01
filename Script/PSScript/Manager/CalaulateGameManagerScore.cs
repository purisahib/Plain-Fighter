using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CalaulateGameManagerScore : MonoBehaviour
{
    enum PlayState
    {
        None,
        Countdown,
        Play,
        GameOver,
        Option
    }
    
    //Player Text
    public Text HighScoreText;
    public Text HighScoreText1;
    public Text ScoreText;
    public Text ScoreText1;
    // Score
    public AudioHandeler audioHandeler;
    public Shooting shootObj;
    public PlainFighterPlayer plainFighterPlayer;

    // Static Obj
    public static bool GameOver = false;

// --------------------------------***********      Button programming         ************--------------------------------//
    public void PlayGame() // PlayGame
    {
        //Time.timeScale = 1.0f;
        StartPageState(PlayState.Countdown);
        PlayButtonAudio();
    }
    public void OptionGame() // Push Game
    {
        //Time.timeScale = 0.0f;
        StartPageState(PlayState.Option);
        PlayButtonAudio();
    }
    public void ResumeGame() // Resume Game
    {
        //Time.timeScale = 1.0f;
        StartPageState(PlayState.Play);
        PlayButtonAudio();
    }
    public void Re_StartGame() // ReStart Game
    {
        //Time.timeScale = 1.0f;
        //StartPageState(PlayState.Option);
        PlayButtonAudio();
        StartPageState(PlayState.None);
        //SceneManager.LoadScene(5);
    }
// --------------------------------***********      END Button programming         ************--------------------------------//


// --------------------------------***********      Normal programming         ************--------------------------------//
    private void Start() {
        StartPageState(PlayState.None);
        //Time.timeScale = 0.0f;
    }

    private void Update() {
        TextSttend();
        GameOverFun();

    }
    private void GameOverFun()
    {
        if (GameOver == true)
        {
            StartPageState(PlayState.GameOver);
            GameOver = false;
        }
    }

    private void TextSttend()
    {
        ScoreText.text = "" + PlainFighterPlayer.Score;
        ScoreText1.text = "" + PlainFighterPlayer.Score;
        HighScoreText.text = "" + PlayerPrefs.GetInt("ScoreLevel3");
        HighScoreText1.text = "" + PlayerPrefs.GetInt("ScoreLevel3");
    }
// --------------------------------***********      END Normal programming         ************--------------------------------//

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
    public TMP_Text countdownText;
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

    private void PlayButtonAudio()
    {
        AudioManager.Instance.PlaySFX(audioHandeler.musicButton);
    }

    private void PlayNoneStateFun()
    {
        shootObj.UpDateValue();
        plainFighterPlayer.UpDateValue();
    }
    
}
