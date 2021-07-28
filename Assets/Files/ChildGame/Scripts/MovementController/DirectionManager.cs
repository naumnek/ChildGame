using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ScrollDirectionManager { LeftToRight, RightToLeft };

public class DirectionManager : MonoBehaviour
{
    //”станавливаем направление, в котором движетс€ камера 
    public ScrollDirectionManager scrollDirection = ScrollDirectionManager.LeftToRight;
    ScrollDirectionManager direction;

    public static DirectionManager instance = null; //синглтон

    void Start()
    {
        int random = Random.Range(0, 1); //добавл€ем рандома

        direction = scrollDirection;
        instance = this;
    }

    void Update()
    {
        //ѕредотвращаем изменени€ переменной в режиме выполнени€
        if (direction != scrollDirection)
        {
            scrollDirection = direction;
        }
    }
}
