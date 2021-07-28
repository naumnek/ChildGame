using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class NumbersManager : MonoBehaviour
{
    public List<GameObject> listNumbers = new List<GameObject>(); //список цифр на сцене
    public ColorManager colorManager; 
    public GameMenu gameMenu;
    public NumbersGenerator numbersGenerator;

    private int m_currentNumber = 0; //текущая цифра

    public void GetSettingNumber(GameObject number)
    {
        listNumbers.Add(number); //добавляем обьект в список
        colorManager.GenerateColor(number); //даём обьекту цвет
        number.GetComponent<TapLogic>().numbersManager = GetComponent<NumbersManager>(); //даём TapLogic наш скрипт
    }

    public void CheckTapNumber(int number)
    {
        number -= 1; //отнимаем единицу т.к. отсчет массива начинается с 0
        if (number == listNumbers.Count - 1) //проверяем на все ли цифры нажал пользователь
        {
            gameMenu.gameover(); //заканчиваем игру
        }
        else
        {
            GameObject obj = listNumbers[number];
            m_currentNumber++;
            for (int i = 0; i < listNumbers.Count; i++)
            {
                listNumbers[i].GetComponent<TapLogic>().currentNumber = m_currentNumber;
            }
            colorManager.SetColorNumber(listNumbers, m_currentNumber); //меняем цвета всех обьектов
        }
    }
}
