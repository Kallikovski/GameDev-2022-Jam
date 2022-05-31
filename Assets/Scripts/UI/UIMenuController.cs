using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIMenuController : MonoBehaviour
{
    [SerializeField] private Animator transition;
    [SerializeField] private GameObject controlMenu;
    [SerializeField] private GameObject mainMenu;
    public void onGameStart()
    {
        StartCoroutine(LoadLevel("Game"));
    }
    
    public void onOpenControlls()
    {
        controlMenu.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void onOpenMain()
    {
        controlMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    IEnumerator LoadLevel(string levelName)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(levelName);
    }
}
