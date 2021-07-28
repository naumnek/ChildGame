using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumbersGenerator : MonoBehaviour
{
    [Header("Options Numbers")]
    public List<GameObject> listNumbers = new List<GameObject>(); //список цифр на сцене
    public GameObject[] prefabsNumbers; //список префабов цифр
    public List<Transform> parentsNumber = new List<Transform>(); //список родительских обьектов на сцене
    [Header("Options Generate")]
    public int maxCount = 18;
    public float minSpawnInterval = 6;
    public float maxSpawnInterval = 18; 
    public float limitOffScreenSpawn = 3f; //спавн от центра экрана по X
    [Header("Options Objects")]
    public float moveDuration = 20f;
    [Range(1.0f, 10.0f)]
    public float multiplierMax = 1.5f;
    public float minYScreenSpawn; //спавн от нижней части экрана
    public float maxYScreenSpawn; //спавна от верхней части экрана
    public float limitOffScreenMove = 1f; //спавн от центра экрана по X
    [Header("Other")]
    public ColorManager colorManager;
    public NumbersManager numbersManager;
    [System.NonSerialized]
    public int currentNumber = 0;

    int spawnCount = 0; //число заспавненых обьектов
    int numberCount = 0; //число заспавненых обьектов
    float YPosition; //высота спавна.
    bool spawn = true;
    System.Random ran = new System.Random();
    List<int> randomNumbers = new List<int>();

    void Start()
    {
        int ii = 0;
        //записываем цифры в список поочередно        
        for (int i = 0; i < maxCount; i++)
        {
            randomNumbers.Add(ii);
            ii+=1;
            if (ii >= prefabsNumbers.Length) ii = 0;
        }
        // реализация алгоритма перестановки
        for (int i = randomNumbers.Count - 1; i >= 1; i--)
        {
            int j = ran.Next(i + 1);
            // обменять значения data[j] и data[i]
            var temp = randomNumbers[j];
            randomNumbers[j] = randomNumbers[i];
            randomNumbers[i] = temp;
        }
        //проверка
        /*
        string list = "Random: ";
        for (int i = 0; i < randomNumbers.Count - 1; i++)
        {
            list += randomNumbers[i];
        }
        print(list);*/

    }

    void Update()
    {
        if(spawnCount < maxCount && spawn)
        {
            spawn = false;
            spawnCount += 1;
            StartCoroutine(Generate());
        }        
    }

    IEnumerator Generate()
    {

        //делаем время активации рандомным
        yield return new WaitForSeconds(Random.Range(minSpawnInterval, maxSpawnInterval));

        //генерируем Y координату обьекта
        YPosition = Random.Range(minYScreenSpawn, maxYScreenSpawn);
        //поочередно и рандомно спавним обьекты
        GameObject obj = Instantiate(prefabsNumbers[randomNumbers[numberCount]], Camera.main.ViewportToWorldPoint(new Vector2(-limitOffScreenSpawn, 0)), Quaternion.identity);
        //назначаем обьекту родителя
        obj.transform.SetParent(parentsNumber[randomNumbers[numberCount]], false);

        //настраиваем обьект
        SettingsObject(obj);
        //устанавливаем координаты движений обьекта
        SetMovePositionObject(obj);
        //соохраняем и делимся обьектом
        SaveShareInfo(obj);
    }

    private void SettingsObject(GameObject obj)
    {
        //вешаем скрипты на обьект
        obj.AddComponent<MoveObject>();
        obj.AddComponent<TapLogic>();
        //даём обьекту цвет
        colorManager.GenerateColor(obj); //даём обьекту цвет
        //даём обьекту скрипт
        obj.GetComponent<TapLogic>().number = randomNumbers[numberCount] + 1; //даём TapLogic наш скрипт
        obj.GetComponent<TapLogic>().m_numbersManager = numbersManager; //даём TapLogic наш скрипт
    }

    private void SetMovePositionObject(GameObject obj)
    {
        //назначаем место спавна и конечный пункт обьекта за пределами экрана
        Vector2 spawnPosition = Camera.main.ViewportToWorldPoint(new Vector2(-limitOffScreenMove, YPosition));
        //spawnPosition = new Vector2(spawnPosition.x, YPosition);
        Vector2 movePosition = Camera.main.ViewportToWorldPoint(new Vector2(limitOffScreenMove, YPosition));
        //movePosition = new Vector2(movePosition.x, YPosition);
        //назначаем координату начальной и конечной позиции обьекта
        obj.GetComponent<MoveObject>().startPosition = spawnPosition;
        obj.GetComponent<MoveObject>().endPosition = movePosition;
    }

    private void SaveShareInfo(GameObject obj)
    {
        //добавляем в список
        listNumbers.Add(obj);
        //вызываем метод SettingsNumbers для генерации цвета обьектам
        numbersManager.GetInfoNumbers(parentsNumber, listNumbers);

        numberCount += 1;
        if (randomNumbers.Count - 1 <= numberCount) numberCount = 0;
        spawn = true;
    }
}
