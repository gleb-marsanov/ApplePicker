using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//Напомню, эта библиотека нужна для работы с ГИП

public class HighScore : MonoBehaviour
{
    static public int score = 1000;

    void Awake()
    {
        //Если значение HighScore уже существует в PlayerPrefs, прочитать его
        if (PlayerPrefs.HasKey("HighScore"))
        {
            score = PlayerPrefs.GetInt("HighScore");
        }
        //Сохранить высшее достижение HighScore в хранилище
        PlayerPrefs.SetInt("HighScore", score);
    }

    void Start()
    {
        
    }

    void Update()
    {
        Text gt = this.GetComponent<Text>();
        gt.text = "High Score: " + score;
        //Обновить HightScore в PlayerPrefs, если необходимо
        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}
