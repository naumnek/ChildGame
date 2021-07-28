using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ColorManager : MonoBehaviour
{
    public Transform numberSprite;
    public Sprite[] spritesNumbers; //спрайты цифр
    public Color[] colors; //цвета
    public GameObject totalNumber; //отображение текущей цифры

    private Color m_CurrentColor; //текущая цвет
    private int m_currentNumber = 0; //текущая цифра

    void Start()
    {
        //генерируем цвета
        SetCurrentColor();
        totalNumber.GetComponent<Image>().color = m_CurrentColor;
        //создаем эффект выскакивания для цифры отсчета
        Sequence mySequence = DOTween.Sequence(); 
        mySequence.Append(totalNumber.transform.DOScale(1.2f, 0.4f));
        mySequence.Append(totalNumber.transform.DOScale(0.95f, 0.4f));
        mySequence.Append(totalNumber.transform.DOScale(1f, 0.4f));
    }

    private void SetCurrentColor() //генерируеми назначаем текущий цвет
    {
        int random = Random.Range(1, colors.Length);
        m_CurrentColor = colors[random];
        colors[random] = colors[0];
        colors[0] = m_CurrentColor;
    }

    public void SetColorNumber(List<Transform> parentsNumber, int currentNumber)
    {
        m_currentNumber = currentNumber;
        for(int i = 0; i < parentsNumber.Count; i++) //перебираем каждую родительский обьект с цифрами
        {
            if(i == currentNumber) //если родительский обьект подходит к текущей цифры
            {
                //делаем цифру отсчета копией текущих игровых цифр
                totalNumber.GetComponent<RectTransform>().sizeDelta = parentsNumber[i].GetChild(0).GetComponent<RectTransform>().sizeDelta; //ширину и высоту Image
                totalNumber.GetComponent<Image>().color = m_CurrentColor; //назначаем текущий цвет цифре отсчета
                totalNumber.GetComponent<Image>().sprite = parentsNumber[i].GetChild(0).GetComponent<Image>().sprite; //копируем спрайт
                numberSprite = parentsNumber[i]; //копируем спрайт

                for (int ii = 0; ii < parentsNumber[i].childCount; ii++) //то меняем цвет всех дочерних цифр в нем на текущий
                {
                    parentsNumber[i].GetChild(ii).GetComponent<Image>().color = m_CurrentColor;
                }
            }
            else //иначе просто даём другой цвет
            {
                for (int ii = 0; ii < parentsNumber[i].childCount; ii++)
                {
                    parentsNumber[i].GetChild(ii).GetComponent<Image>().color = colors[Random.Range(1, colors.Length)];
                }
            }

        }
        //генерируем новый текущий цвет
        SetCurrentColor();
    }

    public void GenerateColor(GameObject objNumber)
    {
        objNumber.GetComponent<Image>().color = colors[Random.Range(1, colors.Length)];
    }
}
