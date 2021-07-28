using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumbersGenerator : MonoBehaviour
{
    [Header("Options Numbers")]
    public List<GameObject> listNumbers = new List<GameObject>(); //������ ���� �� �����
    public GameObject[] prefabsNumbers; //������ �������� ����
    public List<Transform> parentsNumber = new List<Transform>(); //������ ������������ �������� �� �����
    [Header("Options Generate")]
    public int maxCount = 18;
    public float minSpawnInterval = 6;
    public float maxSpawnInterval = 18; 
    public float limitOffScreenSpawn = 3f; //����� �� ������ ������ �� X
    [Header("Options Objects")]
    public float moveDuration = 20f;
    [Range(1.0f, 10.0f)]
    public float multiplierMax = 1.5f;
    public float minYScreenSpawn; //����� �� ������ ����� ������
    public float maxYScreenSpawn; //������ �� ������� ����� ������
    public float limitOffScreenMove = 1f; //����� �� ������ ������ �� X
    [Header("Other")]
    public ColorManager colorManager;
    public NumbersManager numbersManager;
    [System.NonSerialized]
    public int currentNumber = 0;

    int spawnCount = 0; //����� ����������� ��������
    int numberCount = 0; //����� ����������� ��������
    int placeLine = 0; //����� � �������
    float YPosition; //������ ������.
    bool spawn = true;
    System.Random ran = new System.Random();
    List<int> randomNumbers = new List<int>();

    void Start()
    {
        //���������� ����� � ������ ����������        
        for (int i = 0; i < maxCount; i++)
        {
            int ii = 0;
            randomNumbers.Add(ii);
            ii+=1;
            if (ii >= prefabsNumbers.Length) ii = 0;
        }
        // ���������� ��������� ������������
        for (int i = randomNumbers.Count - 1; i >= 1; i--)
        {
            int j = ran.Next(i + 1);
            // �������� �������� data[j] � data[i]
            var temp = randomNumbers[j];
            randomNumbers[j] = randomNumbers[i];
            randomNumbers[i] = temp;
        }
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
        //���������� Y ���������� �������
        YPosition = Random.Range(minYScreenSpawn, maxYScreenSpawn);
        print("Number: " + randomNumbers[numberCount]);
        //���������� � �������� ������� �������
        GameObject obj = Instantiate(prefabsNumbers[randomNumbers[numberCount]], Camera.main.ViewportToWorldPoint(new Vector2(-limitOffScreenSpawn, 0)), Quaternion.identity);
        numberCount += 1;
        if (randomNumbers.Count - 1 >= numberCount) numberCount = 0;
        //��������� ������� ��������
        obj.transform.SetParent(parentsNumber[placeLine], false);

        //������ ����� ��������� ���������
        yield return new WaitForSeconds(Random.Range(minSpawnInterval, maxSpawnInterval));

        //����������� ������
        SettingsObject(obj);
        //������������� ���������� �������� �������
        SetMovePositionObject(obj);
        //���������� � ������� ��������
        SaveShareInfo(obj);

        //��������� �� �������� �� �� �����
        placeLine += 1;
        if (placeLine >= parentsNumber.Count) placeLine = 0;
    }

    private void SettingsObject(GameObject obj)
    {
        //������ ������� �� ������
        obj.AddComponent<MoveObject>();
        obj.AddComponent<TapLogic>();
        //��� ������� ����
        colorManager.GenerateColor(obj); //��� ������� ����
        //��� ������� ������
        obj.GetComponent<TapLogic>().m_numbersManager = numbersManager; //��� TapLogic ��� ������
    }

    private void SetMovePositionObject(GameObject obj)
    {
        //��������� ����� ������ � �������� ����� ������� �� ��������� ������
        Vector2 spawnPosition = Camera.main.ViewportToWorldPoint(new Vector2(-limitOffScreenMove, YPosition));
        //spawnPosition = new Vector2(spawnPosition.x, YPosition);
        Vector2 movePosition = Camera.main.ViewportToWorldPoint(new Vector2(limitOffScreenMove, YPosition));
        //movePosition = new Vector2(movePosition.x, YPosition);
        //��������� ���������� ��������� � �������� ������� �������
        obj.GetComponent<MoveObject>().startPosition = spawnPosition;
        obj.GetComponent<MoveObject>().endPosition = movePosition;
    }

    private void SaveShareInfo(GameObject obj)
    {
        //��������� � ������
        listNumbers.Add(obj);
        //�������� ����� SettingsNumbers ��� ��������� ����� ��������
        numbersManager.GetInfoNumbers(parentsNumber, listNumbers);
        spawn = true;
    }
}
