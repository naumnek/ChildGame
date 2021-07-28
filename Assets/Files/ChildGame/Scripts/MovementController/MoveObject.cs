using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveObject : MonoBehaviour
{
    [Header("Screen")]
    public float limitOffScreen = 3f; //отступ от камеры

    [Header("Speed Random")]
    public float minSpeed = 0.2f; //чем больше значение тем медленее
    public float maxSpeed = 0.6f;
    float speed;

    [Header("Scale Random")]
    [Range(1.0f, 10.0f)]
    public float multiplierMax = 3f;
    Vector3 startScale;

    void Start()
    {
        startScale = transform.localScale;

        Move();
    }

    void Move()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        //инициируем последовательность
        Sequence mySequence = DOTween.Sequence();
        //телепортируем цифру за экран
        mySequence.Append(transform.DOMove(Camera.main.ViewportToWorldPoint(new Vector3(-limitOffScreen, 0, 0)), 0));
        //делаем изменение размера постоянными на протяжении всей последовательности
        mySequence.Insert(0, transform.DOScale(startScale * Random.Range(1f, multiplierMax), mySequence.Duration()));
        //двигаем цифру на противоположный конец экрана
        mySequence.Append(transform.DOMove(Camera.main.ViewportToWorldPoint(new Vector3(limitOffScreen, 0, 0)), speed));
        mySequence.OnComplete(Move);
    }
}
