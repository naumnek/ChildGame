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
    public NumbersManager m_numbersManager;
    public int currentNumber = 0;

    MoveObject moveObject;

    void Start()
    {
        moveObject = GetComponent<MoveObject>();
    }

    public void OnPointerEnter(PointerEventData eventData) //тригер проверяет нажал ли пользователь на цифру
    {
        if(number - 1 == currentNumber) //проверяем подходит ли наша цифра под текущую
        {
            moveObject.TriggerRightTap();
            m_numbersManager.CheckTapNumber(number);
        }
        else
        {
            transform.DOShakeScale(1);
        }

    }
}
