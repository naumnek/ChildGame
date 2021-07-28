using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumbersGenerator : MonoBehaviour
{
    [Header("Options Numbers")]
    public List<GameObject> listNumbers = new List<GameObject>(); //список цифр на сцене
    public GameObject[] prefabsNumbers; //список префабов цифр
    public Transform parentNumber;
    [Header("Options Generate")]
    public int maxCount = 27;
    public float minSpawnInterval = 6;
    public float maxSpawnInterval = 18;
    public float limitOffScreenSpawn = 3f;
    [Header("Other")]
    public NumbersManager numbersManager;

    int spawnCount = 0; //число заспавненых обьектов
    int placeLine = 0; //число в очереди

    void Update()
    {
        if(spawnCount < maxCount)
        {
            spawnCount += 1;
            StartCoroutine(Generate());
        }        
    }

    IEnumerator Generate()
    {
        //делаем время спавна радомным
        yield return new WaitForSeconds(Random.Range(minSpawnInterval, maxSpawnInterval));
        //назначаем место спавна обьекта пределом экрана
        Vector3 spawnPosition = Camera.main.ViewportToWorldPoint(new Vector3(-limitOffScreenSpawn, 0, 0));
        //поочередно спавим обьекты
        GameObject obj = Instantiate(prefabsNumbers[placeLine], spawnPosition, Quaternion.identity);
        if (placeLine < 8) placeLine += 1;
        else placeLine = 0;
        //назначаем обьекту родителя
        obj.transform.SetParent(parentNumber, false);
        //добавляем в список
        listNumbers.Add(obj);
        //вызываем метод SettingsNumbers для генерации цвета обьектам
        numbersManager.GetSettingNumber(obj);
    }
}
