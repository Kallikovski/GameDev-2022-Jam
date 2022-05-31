using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateController : MonoBehaviour
{
    public GameManager gameManager;
    public PlayerStats player;
    private void Awake()
    {
        //
    }

    // Update is called once per frame
    private void Update()
    {
        if (player.playerHealthPoints <= 0)
        {
            if (gameManager)
            {
                gameManager.UpdateGameState(GameManager.State.End);
            }
        }
    }
}
