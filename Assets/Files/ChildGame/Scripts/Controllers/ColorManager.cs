using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorManager : MonoBehaviour
{
    public GameObject menuNumber; //отображение текущей цифры
    public Sprite[] spritesNumbers; //спрайты цифр
    public Color[] colors; //цвета

    private Color m_CurrentColor; //текущая цвет
    private int m_currentNumber = 0; //текущая цифра

    void Start()
    {
        SetCurrentColor();
        menuNumber.GetComponent<Image>().color = m_CurrentColor;
    }

    private void SetCurrentColor() //генерируеми назначаем текущий цвет
    {
        int random = Random.Range(1, colors.Length);
        m_CurrentColor = colors[random];
        colors[random] = colors[0];
        colors[0] = m_CurrentColor;
    }

    public void SetColorNumber(List<GameObject> gameNumbers, int currentNumber)
    {
        m_currentNumber = currentNumber;
        //рандомно назначаем другим цифрам все цвета, кроме текущего
        for (int i = 0; i != gameNumbers.Count; i++) 
        {
            gameNumbers[i].GetComponent<Image>().color = colors[Random.Range(1, colors.Length)];
        }
        //делаем цифру отсчета копией игровой цифры 
        menuNumber.GetComponent<Image>().sprite = gameNumbers[m_currentNumber].GetComponent<Image>().sprite;
        menuNumber.GetComponent<RectTransform>().sizeDelta = gameNumbers[m_currentNumber].GetComponent<RectTransform>().sizeDelta;
        //делаем цифру отсчета и игровую цифру одинакового цвета
        menuNumber.GetComponent<Image>().color = m_CurrentColor;
        gameNumbers[m_currentNumber].GetComponent<Image>().color = m_CurrentColor;
        SetCurrentColor();
    }

    public void GenerateColor(GameObject number)
    {
        number.GetComponent<Image>().color = colors[Random.Range(1, colors.Length)];
    }
}
