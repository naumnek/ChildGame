using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumbersGenerator : MonoBehaviour
{
    [Header("Options Numbers")]
    public List<GameObject> listNumbers = new List<GameObject>(); //������ ���� �� �����
    public GameObject[] prefabsNumbers; //������ �������� ����
    public Transform parentNumber;
    [Header("Options Generate")]
    public int maxCount = 27;
    public float minSpawnInterval = 6;
    public float maxSpawnInterval = 18;
    public float limitOffScreenSpawn = 3f;
    [Header("Other")]
    public NumbersManager numbersManager;

    int spawnCount = 0; //����� ����������� ��������
    int placeLine = 0; //����� � �������

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
        //������ ����� ������ ��������
        yield return new WaitForSeconds(Random.Range(minSpawnInterval, maxSpawnInterval));
        //��������� ����� ������ ������� �������� ������
        Vector3 spawnPosition = Camera.main.ViewportToWorldPoint(new Vector3(-limitOffScreenSpawn, 0, 0));
        //���������� ������ �������
        GameObject obj = Instantiate(prefabsNumbers[placeLine], spawnPosition, Quaternion.identity);
        if (placeLine < 8) placeLine += 1;
        else placeLine = 0;
        //��������� ������� ��������
        obj.transform.SetParent(parentNumber, false);
        //��������� � ������
        listNumbers.Add(obj);
        //�������� ����� SettingsNumbers ��� ��������� ����� ��������
        numbersManager.GetSettingNumber(obj);
    }
}
