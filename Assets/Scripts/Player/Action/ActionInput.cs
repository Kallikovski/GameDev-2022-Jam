using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionInput : MonoBehaviour
{
    public GameManager gameManager;
    public bool getInput;

    private void Awake()
    {
        if (gameManager)
        {
            gameManager.onGameStateChange += updateGetInput;
        }
    }
    public void Initialize()
    {
        gameManager.onGameStateChange += updateGetInput;
    }
    private void Update()
    {
        if (getInput)
        {
            ActionShoot Script = GetComponent<ActionShoot>();
            if (Input.GetMouseButtonDown(0))
            {
                Script.SpawnProjectile();
            }
        }
    }

    private void updateGetInput(GameManager.State state)
    {
        if(state == GameManager.State.Running)
        {
            getInput = true;
        }
        else
        {
            getInput = false;
        }
    }
}
