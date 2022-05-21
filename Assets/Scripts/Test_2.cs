using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_2 : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    private void Awake()
    {
        endGame();
    }

    private void endGame()
    {
        gameManager.UpdateGameState(GameManager.State.End);
    }
}
