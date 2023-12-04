using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScore : MonoBehaviour
{
    public void SetScore(int score)
    {
        PlayerPrefs.SetInt("HighScore", score);
    }

    public int GetScore()
    {
        return PlayerPrefs.GetInt("HighScore");
    }
    
}
