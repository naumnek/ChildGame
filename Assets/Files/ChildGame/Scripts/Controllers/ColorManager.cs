using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorManager : MonoBehaviour
{
    public GameObject menuNumber; //����������� ������� �����
    public Sprite[] spritesNumbers; //������� ����
    public Color[] colors; //�����

    private Color m_CurrentColor; //������� ����
    private int m_currentNumber = 0; //������� �����

    void Start()
    {
        SetCurrentColor();
        menuNumber.GetComponent<Image>().color = m_CurrentColor;
    }

    private void SetCurrentColor() //����������� ��������� ������� ����
    {
        int random = Random.Range(1, colors.Length);
        m_CurrentColor = colors[random];
        colors[random] = colors[0];
        colors[0] = m_CurrentColor;
    }

    public void SetColorNumber(List<GameObject> gameNumbers, int currentNumber)
    {
        m_currentNumber = currentNumber;
        //�������� ��������� ������ ������ ��� �����, ����� ��������
        for (int i = 0; i != gameNumbers.Count; i++) 
        {
            gameNumbers[i].GetComponent<Image>().color = colors[Random.Range(1, colors.Length)];
        }
        //������ ����� ������� ������ ������� ����� 
        menuNumber.GetComponent<Image>().sprite = gameNumbers[m_currentNumber].GetComponent<Image>().sprite;
        menuNumber.GetComponent<RectTransform>().sizeDelta = gameNumbers[m_currentNumber].GetComponent<RectTransform>().sizeDelta;
        //������ ����� ������� � ������� ����� ����������� �����
        menuNumber.GetComponent<Image>().color = m_CurrentColor;
        gameNumbers[m_currentNumber].GetComponent<Image>().color = m_CurrentColor;
        SetCurrentColor();
    }

    public void GenerateColor(GameObject number)
    {
        number.GetComponent<Image>().color = colors[Random.Range(1, colors.Length)];
    }
}
