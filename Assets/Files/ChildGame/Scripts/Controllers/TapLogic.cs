using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;


public class TapLogic : MonoBehaviour, IPointerEnterHandler
{
    public int number;

    [System.NonSerialized]
    public NumbersManager numbersManager;
    public int currentNumber = 0;

    public void OnPointerEnter(PointerEventData eventData) //������ ��������� ����� �� ������������ �� �����
    {
        if(number == currentNumber) //��������� �������� �� ���� ����� ��� �������
        {
            numbersManager.CheckTapNumber(number);
        }
        else
        {
            transform.DOShakeScale(1);
        }

    }
}
