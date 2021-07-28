using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    [Header("Options GameMenu")]
    public GameObject endMenu;
    public List<GameObject> DisableUI = new List<GameObject> {};

    public void LoadScene(string scene)
    {
        StartCoroutine(wait(scene));
    }

    public void gameover()
    {
        foreach (GameObject copy in DisableUI)
        {
            copy.SetActive(false);
        }
        endMenu.SetActive(true);
    }

    IEnumerator wait(string scene)
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(scene);
    }
}
