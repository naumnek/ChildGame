using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class NumbersManager : MonoBehaviour
{
    public int currentNumber = 0; //������� �����
    public ColorManager colorManager; 
    public GameMenu gameMenu;
    public NumbersGenerator numbersGenerator;

    private List<Transform> m_parentsNumbers = new List<Transform>(); //������ ������������ ���� �� �����
    private List<GameObject> m_listNumbers = new List<GameObject>(); //������ ���� �� �����

    void Start()
    {
        numbersGenerator.currentNumber = currentNumber;
    }

    public void GetInfoNumbers(List<Transform> parentNumber, List<GameObject> listNumbers)
    {
        m_parentsNumbers = parentNumber;
        m_listNumbers = listNumbers;
    }

    public void CheckTapNumber(int number)
    {
        if (number == m_parentsNumbers.Count) //��������� �� ��� �� ����� ����� ������������
        {
            gameMenu.gameover(); //����������� ����
        }
        else
        {
            SetCurrentNumber();
        }
    }

    public void SetCurrentNumber()
    {
        currentNumber += 1; //������ ������� �����
        //�������� ������� ������ NumberGenerator
        numbersGenerator.currentNumber = currentNumber;
        for (int i = 0; i < m_listNumbers.Count; i++)
        {
            m_listNumbers[i].GetComponent<TapLogic>().currentNumber = currentNumber; //������ ������� ����� �� ���� TapLogic
        }
        colorManager.SetColorNumber(m_parentsNumbers, currentNumber); //������ ����� ���� ��������

    }
}
