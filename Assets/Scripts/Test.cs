using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    // Start is called before the first frame update
    private void Awake()
    {
        gameManager.onGameStateChange += GameEnd;
    }

    private void GameEnd(GameManager.State state)
    {
        if (state == GameManager.State.End)
        {
            Debug.Log("Game End");
        }
    }
}
