using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HSScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI HighScore;

    void Start()
    {
        GameObject obj = GameObject.Find("TetrisPlayAGAIN");
        SaveScore sav = obj.GetComponent<SaveScore>();
        HighScore.text = sav.GetScore().ToString();
    }
    
    public void OnClick()
    {
        SceneManager.LoadScene("Tetris");
    }
    
}
