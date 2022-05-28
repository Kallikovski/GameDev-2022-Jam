using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIPauseMenuController : MonoBehaviour
{
    [SerializeField] private Animator transition;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject endMenu;
    [SerializeField] private GameObject controlMenu;
    private void Awake()
    {
        gameManager.onGameStateChange += onUpdateUI;
        gameManager.UpdateGameState(GameManager.State.Start);
    }

    private void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            gameManager.UpdateGameState(GameManager.State.Pause);
        }
    }

    private void onUpdateUI(GameManager.State state)
    {
        startMenu.SetActive(false);
        pauseMenu.SetActive(false);
        endMenu.SetActive(false);
        switch (state)
        {
            case GameManager.State.Start:
                startMenu.SetActive(true);
                break;
            case GameManager.State.Running:
                break;
            case GameManager.State.Pause:
                pauseMenu.SetActive(true);
                break;
            case GameManager.State.End:
                endMenu.SetActive(true);
                break;
            default:
                break;
        }
    }

    public void RunGame()
    {
        gameManager.UpdateGameState(GameManager.State.Running);
    }
    public void onBackToMenu()
    {
        StartCoroutine(LoadLevel("Menu"));
    }

    public void onOpenControlls()
    {
        pauseMenu.SetActive(false);
        controlMenu.SetActive(true);
    }
    public void onCloseControlls()
    {
        controlMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }


    IEnumerator LoadLevel(string levelName)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(levelName);
    }
}
