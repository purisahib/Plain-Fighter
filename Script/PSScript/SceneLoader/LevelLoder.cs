using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelLoder : MonoBehaviour
{
    public GameObject loadingScreen;
    public GameObject OldScreen;
    public Slider slider;
    public TMP_Text progressText;
    public void LoadLevel (int sceneIndex)
    {
        StartCoroutine (LoadAsynchronously(sceneIndex));        
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

    public void Quit_Game()
    {
        Application.Quit();       
    }

}
