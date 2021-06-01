using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Text))]
public class YourScoreText  : MonoBehaviour
{
    Text Score;
    void Update(){
        Score = GetComponent<Text>();
        Score.text = "Your Score: " + GameManager.scoreForShow;
    }
}
