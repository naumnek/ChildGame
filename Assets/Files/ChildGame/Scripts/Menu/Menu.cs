using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class Menu : MonoBehaviour
{
    public GameObject menu;

    void Start()
    {
        StartCoroutine(waitBounce());
    }

    public void LoadScene(string scene)
    {
        //создаем эффект bounce исчезновения
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(menu.transform.DOScale(0.95f, 0.4f));
        mySequence.Append(menu.transform.DOScale(1.2f, 0.4f));
        mySequence.Append(menu.transform.DOScale(0f, 0.4f));
        StartCoroutine(wait(scene));
    }
    IEnumerator waitBounce()
    {
        yield return new WaitForSeconds(2f);
        //создаем эффект bounce появления
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(menu.transform.DOScale(1.2f, 0.4f));
        mySequence.Append(menu.transform.DOScale(0.95f, 0.4f));
        mySequence.Append(menu.transform.DOScale(1f, 0.4f));
    }

    IEnumerator wait(string scene)
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(scene);
    }

    public void ButtonExit() //выход из игры
    {
        Application.Quit();
    }
}
