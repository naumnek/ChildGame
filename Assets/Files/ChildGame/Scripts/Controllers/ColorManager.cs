using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ColorManager : MonoBehaviour
{
    public Transform numberSprite;
    public Sprite[] spritesNumbers; //������� ����
    public Color[] colors; //�����
    public GameObject totalNumber; //����������� ������� �����

    private Color m_CurrentColor; //������� ����
    private int m_currentNumber = 0; //������� �����

    void Start()
    {
        //���������� �����
        SetCurrentColor();
        totalNumber.GetComponent<Image>().color = m_CurrentColor;
        //������� ������ ������������ ��� ����� �������
        Sequence mySequence = DOTween.Sequence(); 
        mySequence.Append(totalNumber.transform.DOScale(1.2f, 0.4f));
        mySequence.Append(totalNumber.transform.DOScale(0.95f, 0.4f));
        mySequence.Append(totalNumber.transform.DOScale(1f, 0.4f));
    }

    private void SetCurrentColor() //����������� ��������� ������� ����
    {
        int random = Random.Range(1, colors.Length);
        m_CurrentColor = colors[random];
        colors[random] = colors[0];
        colors[0] = m_CurrentColor;
    }

    public void SetColorNumber(List<Transform> parentsNumber, int currentNumber)
    {
        m_currentNumber = currentNumber;
        for(int i = 0; i < parentsNumber.Count; i++) //���������� ������ ������������ ������ � �������
        {
            if(i == currentNumber) //���� ������������ ������ �������� � ������� �����
            {
                //������ ����� ������� ������ ������� ������� ����
                totalNumber.GetComponent<RectTransform>().sizeDelta = parentsNumber[i].GetChild(0).GetComponent<RectTransform>().sizeDelta; //������ � ������ Image
                totalNumber.GetComponent<Image>().color = m_CurrentColor; //��������� ������� ���� ����� �������
                totalNumber.GetComponent<Image>().sprite = parentsNumber[i].GetChild(0).GetComponent<Image>().sprite; //�������� ������
                numberSprite = parentsNumber[i]; //�������� ������

                for (int ii = 0; ii < parentsNumber[i].childCount; ii++) //�� ������ ���� ���� �������� ���� � ��� �� �������
                {
                    parentsNumber[i].GetChild(ii).GetComponent<Image>().color = m_CurrentColor;
                }
            }
            else //����� ������ ��� ������ ����
            {
                for (int ii = 0; ii < parentsNumber[i].childCount; ii++)
                {
                    parentsNumber[i].GetChild(ii).GetComponent<Image>().color = colors[Random.Range(1, colors.Length)];
                }
            }

        }
        //���������� ����� ������� ����
        SetCurrentColor();
    }

    public void GenerateColor(GameObject objNumber)
    {
        objNumber.GetComponent<Image>().color = colors[Random.Range(1, colors.Length)];
    }
}
