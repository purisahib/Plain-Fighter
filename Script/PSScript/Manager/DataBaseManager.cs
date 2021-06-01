using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBaseManager : MonoBehaviour
{
    // Player Score / Coin / Etc...
    public int Score;
    public int BestScore;
    public int Distance;
    public int BestDistance;
    public int Coin;
    public int TotalCoin;

    // Player Function
    void GetData()
    {
        PlayerPrefs.GetInt("ScoreLevel3");
    }
    void SetData()
    {
        PlayerPrefs.SetInt("BestScore", BestScore);
        PlayerPrefs.SetInt("BestDistance", BestDistance);
        if (TotalCoin = PlayerPrefs.GetInt("TotalCoin"))
        {
            TotalCoin += Coin;
            PlayerPrefs.SetInt("TotalCoin", TotalCoin);
        }
    }
}
