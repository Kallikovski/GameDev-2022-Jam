using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionInputAI : MonoBehaviour
{
    private ActionShoot script;
    public GameManager gameManager;
    public bool getInput;

    private void Awake()
    {
        getInput = true;
        gameManager.onGameStateChange += updateGetInput;
        script = GetComponent<ActionShoot>();
    }
    private void Update()
    {
        if (getInput)
        {
            script = GetComponent<ActionShoot>();
            if (script)
            {
                script.SpawnProjectile();
            }
        }
    }

    private void updateGetInput(GameManager.State state)
    {
        if (state == GameManager.State.Running)
        {
            getInput = true;
        }
        else
        {
            getInput = false;
        }
    }
}

