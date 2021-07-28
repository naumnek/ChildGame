using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class GameMenu : MonoBehaviour
{
    [Header("Options GameMenu")]
    public GameObject endMenu;
    public List<GameObject> DisableUI = new List<GameObject> {};

    void Start()
    {

    }

    public void LoadScene(string scene)
    {
        //создаем эффект bounce исчезновения
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(endMenu.transform.DOScale(0.95f, 0.4f));
        mySequence.Append(endMenu.transform.DOScale(1.2f, 0.4f));
        mySequence.Append(endMenu.transform.DOScale(0f, 0.4f));
        StartCoroutine(wait(scene));
    }

    public void gameover()
    {
        foreach (GameObject copy in DisableUI)
        {
            copy.SetActive(false);
        }
        endMenu.SetActive(true);
        //создаем эффект bounce появления
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(endMenu.transform.DOScale(1.2f, 0.4f));
        mySequence.Append(endMenu.transform.DOScale(0.95f, 0.4f));
        mySequence.Append(endMenu.transform.DOScale(1f, 0.4f));
    }

    IEnumerator wait(string scene)
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(scene);
    }
}
