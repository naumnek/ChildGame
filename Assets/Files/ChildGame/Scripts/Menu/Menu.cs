using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public void LoadScene(string scene)
    {
        StartCoroutine(wait(scene));
    }

    IEnumerator wait(string scene)
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(scene);
    }

    public void ButtonExit() //выход из игры
    {
        Application.Quit();
    }
}
