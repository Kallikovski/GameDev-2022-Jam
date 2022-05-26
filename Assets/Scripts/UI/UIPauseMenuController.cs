using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIPauseMenuController : MonoBehaviour
{
    [SerializeField] private Animator transition;
    public void onBackToMenu()
    {
        StartCoroutine(LoadLevel("Menu"));
    }

    public void onOpenControlls()
    {

    }

    IEnumerator LoadLevel(string levelName)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(levelName);
    }
}
