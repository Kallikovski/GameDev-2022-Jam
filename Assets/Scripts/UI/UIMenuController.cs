using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIMenuController : MonoBehaviour
{
    [SerializeField] private Animator transition;
    
    public void onGameStart()
    {
        StartCoroutine(LoadLevel("Game"));
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
