using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ScrollDirectionManager { LeftToRight, RightToLeft };

public class DirectionManager : MonoBehaviour
{
    //������������� �����������, � ������� �������� ������ 
    public ScrollDirectionManager scrollDirection = ScrollDirectionManager.LeftToRight;
    ScrollDirectionManager direction;

    public static DirectionManager instance = null; //��������

    void Start()
    {
        int random = Random.Range(0, 1); //��������� �������

        direction = scrollDirection;
        instance = this;
    }

    void Update()
    {
        //������������� ��������� ���������� � ������ ����������
        if (direction != scrollDirection)
        {
            scrollDirection = direction;
        }
    }
}
