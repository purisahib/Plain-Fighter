﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Text))]
public class HighScoreText : MonoBehaviour
{
    Text highScore;

    void Start(){
        highScore = GetComponent<Text>();
        highScore.text = "High Score: " + PlayerPrefs.GetInt("HighScore").ToString();
    }
}
