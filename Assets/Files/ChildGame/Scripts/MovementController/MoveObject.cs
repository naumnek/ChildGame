using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveObject : MonoBehaviour
{
    [Header("Speed")]
    public float moveDuration = 20f;

    [Header("Scale Random")]
    [Range(1.0f, 10.0f)]
    public float multiplierMax = 1.5f;

    Vector3 startScale;
    public Vector2 startPosition;
    public Vector2 endPosition;

    void Start()
    {
        startScale = transform.localScale;

        Move();
    }

    void Move()
    {
        //���������� ������������������
        Sequence mySequence = DOTween.Sequence();
        //������������� ����� �� �����
        mySequence.Append(transform.DOMove(startPosition, 0));
        //������ ��������� ������� ����������� �� ���������� ���� ������������������
        mySequence.Insert(0, transform.DOScale(startScale * Random.Range(1f, multiplierMax), mySequence.Duration()));
        //������� ����� �� ��������������� ����� ������
        mySequence.Append(transform.DOMove(endPosition, moveDuration));
        mySequence.OnComplete(Move);
    }

    public void TriggerRightTap()
    {
        //������� ������ bounce
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(transform.DOScale(0.95f, 0.4f));
        mySequence.Append(transform.DOScale(1.2f, 0.4f));
        mySequence.Append(transform.DOScale(0f, 0.4f));
        //������������� ����� �� �����
        mySequence.Append(transform.DOMove(startPosition, 0));
    }
}
