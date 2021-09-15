using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//Эта строка подключает библиотеку для работы с ГИП

public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
    public Text scoreGT;
    void Start()
    {
        //Получить ссылку на игровой объект ScoreCounter
        GameObject scoreGo = GameObject.Find("ScoreCounter");
        //Получить компонент Text этого игрового объекта
        scoreGT = scoreGo.GetComponent<Text>();
        //Установить начальное число очков равным 0
        scoreGT.text = "0";
    }
    void Update()
    {
        //Получить текущие координаты указателя мыши на экран из Input
        Vector3 mousePos2D = Input.mousePosition;				

        //Координаты Z камеры определяет, как далеко в трехмерном пространстве
        //находится указатель мыши
        mousePos2D.z = -Camera.main.transform.position.z;			

        //Преобразовать точку на двухмерной плоскости экрана в трехмерные
        //координаты игры
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        //Переместить корзину вдоль оси X в координату X казателя мыши
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }
    void OnCollisionEnter(Collision coll)					
    {
        //Отыскать яблоко, попавшее в эту корзину
        GameObject collidedWith = coll.gameObject;				
        if (collidedWith.tag == "Apple")
        {					
            Destroy(collidedWith);

            //Преобразовать текст в scoreGT в целое число
            int score = int.Parse(scoreGT.text);
            //Добавить очки за пойманное яблоко
            score += 100;
            //Преобразовать число очков обратно в строку и вывести ее на экран
            scoreGT.text = score.ToString();

            //Запомнить высшее достижение
            if (score > HighScore.score)
            {
                HighScore.score = score;
            }
        }
    }

}
