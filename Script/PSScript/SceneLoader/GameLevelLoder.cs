using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameLevelLoder : MonoBehaviour
{
    public GameObject loadingScreen;
    public GameObject OldScreen;
    public Slider slider;
    public TMP_Text progressText;
    int IndexNumber;
    public void Back_Btn(int sceneIndex)//Btn For Back
    {
        StartCoroutine (LoadAsynchronously(IndexNumber));        
    }
    public void LoadLevel (int sceneIndex) // For Loading level
    {
        IndexNumber = sceneIndex;
        LevelMessageLoad(sceneIndex);
    }
    public void RunLevel ()// For Run Level
    {
        StartCoroutine (LoadAsynchronously(IndexNumber));        
    }
    IEnumerator LoadAsynchronously (int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingScreen.SetActive(true);
        OldScreen.SetActive(false);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            slider.value = progress;
            progressText.text = progress * 100f + "%";

            yield return null;
        }
    }

    public TMP_Text GameNameText;
    public Text GameDescriptionText;
    public MessageAttiching messageAttaching;
    private void LevelMessageLoad(int index)
    {
        switch (index)
        {
            case 3:
                GameNameText.text = "" + messageAttaching.NameLevel1;
                GameDescriptionText.text = "" + messageAttaching.DescriptionLevel1;
                break;
            case 4:
                GameNameText.text = "" + messageAttaching.NameLevel2;
                GameDescriptionText.text = "" + messageAttaching.DescriptionLevel2;
                break;
            case 5:
                GameNameText.text = "" + messageAttaching.NameLevel3;
                GameDescriptionText.text = "" + messageAttaching.DescriptionLevel3;
                break;
            case 6:
                GameNameText.text = "" + messageAttaching.NameLevel4;
                GameDescriptionText.text = "" + messageAttaching.DescriptionLevel4;
                break;
            case 7:
                GameNameText.text = "" + messageAttaching.NameLevel5;
                GameDescriptionText.text = "" + messageAttaching.DescriptionLevel5;
                break;
            case 8:
                GameNameText.text = "" + messageAttaching.NameLevel6;
                GameDescriptionText.text = "" + messageAttaching.DescriptionLevel6;
                break;
            case 9:
                GameNameText.text = "" + messageAttaching.NameLevel7;
                GameDescriptionText.text = "" + messageAttaching.DescriptionLevel7;
                break;
            case 10:
                GameNameText.text = "" + messageAttaching.NameLevel8;
                GameDescriptionText.text = "" + messageAttaching.DescriptionLevel8;
                break;
            case 11:
                GameNameText.text = "" + messageAttaching.NameLevel9;
                GameDescriptionText.text = "" + messageAttaching.DescriptionLevel9;
                break;
            case 12:
                GameNameText.text = "" + messageAttaching.NameLevel10;
                GameDescriptionText.text = "" + messageAttaching.DescriptionLevel10;
                break;
            case 13:
                GameNameText.text = "" + messageAttaching.NameLevel11;
                GameDescriptionText.text = "" + messageAttaching.DescriptionLevel11;
                break;
            case 14:
                GameNameText.text = "" + messageAttaching.NameLevel12;
                GameDescriptionText.text = "" + messageAttaching.DescriptionLevel12;
                break;
        }
    }

    public void Quit_Game()
    {
        Application.Quit();       
    }
    

}
