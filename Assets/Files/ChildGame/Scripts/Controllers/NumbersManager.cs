using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class NumbersManager : MonoBehaviour
{
    public List<GameObject> listNumbers = new List<GameObject>(); //������ ���� �� �����
    public ColorManager colorManager; 
    public GameMenu gameMenu;
    public NumbersGenerator numbersGenerator;

    private int m_currentNumber = 0; //������� �����

    public void GetSettingNumber(GameObject number)
    {
        listNumbers.Add(number); //��������� ������ � ������
        colorManager.GenerateColor(number); //��� ������� ����
        number.GetComponent<TapLogic>().numbersManager = GetComponent<NumbersManager>(); //��� TapLogic ��� ������
    }

    public void CheckTapNumber(int number)
    {
        number -= 1; //�������� ������� �.�. ������ ������� ���������� � 0
        if (number == listNumbers.Count - 1) //��������� �� ��� �� ����� ����� ������������
        {
            gameMenu.gameover(); //����������� ����
        }
        else
        {
            GameObject obj = listNumbers[number];
            m_currentNumber++;
            for (int i = 0; i < listNumbers.Count; i++)
            {
                listNumbers[i].GetComponent<TapLogic>().currentNumber = m_currentNumber;
            }
            colorManager.SetColorNumber(listNumbers, m_currentNumber); //������ ����� ���� ��������
        }
    }
}
