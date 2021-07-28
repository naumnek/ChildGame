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

    public void OnPointerEnter(PointerEventData eventData) //тригер проверяет нажал ли пользователь на цифру
    {
        if(number == currentNumber) //проверяем подходит ли наша цифра под текущую
        {
            numbersManager.CheckTapNumber(number);
        }
        else
        {
            transform.DOShakeScale(1);
        }

    }
}
