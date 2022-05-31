using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTransfer : MonoBehaviour
{
    private bool transferActive = false;
    public GameManager gameManager;
    public PlayerStats player;
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
        Debug.Log(gameManager.currentState);
        if(player.playerHealthPoints <= 0 && player.playerSoulFragments > 0)
        {
            gameManager.UpdateGameState(GameManager.State.Transfer);
        }
        if (player.playerHealthPoints <= 0 && player.playerSoulFragments <= 0)
        {
            gameManager.UpdateGameState(GameManager.State.End);
        }
        transferActive = false;
        if (getInput)
        {
            if (Input.GetMouseButtonDown(0))
            {
                transferActive = true;
            }
        }
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            //Debug.Log("Did Hit");
            if (transferActive)
            {
                Debug.Log("Did Transfer");
                gameManager.UpdateGameState(GameManager.State.Running);
                Transfer(hit);
            }
        }
        else
        {
            // Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            //Debug.Log("Did not Hit");
        }
    }

    private void updateGetInput(GameManager.State state)
    {
        if (state == GameManager.State.Transfer)
        {
            getInput = true;
        }
        else
        {
            getInput = false;
        }
    }
    private void Transfer(RaycastHit hit)
    {
        // Get Gameobject
        GameObject target = hit.transform.gameObject;

        Debug.Log(target != null);

        // Update Tags
        target.tag = "Player";

        // Remove Script

        MovementInputAI movementInputScriptAI = target.GetComponent<MovementInputAI>() as MovementInputAI;
        Destroy(movementInputScriptAI);
        ActionInputAI actionInputScriptAI = target.GetComponent<ActionInputAI>() as ActionInputAI;
        Destroy(actionInputScriptAI);

        // Place Camera
        GameObject targetCameraPivot = target.transform.GetChild(0).gameObject;
        Camera camera = Camera.main;
        camera.transform.SetParent(targetCameraPivot.transform);
        camera.transform.position = target.transform.position;
        player.playerHealthPoints = 100;
        player.playerSoulFragments -= 1;

        target.transform.rotation = gameObject.transform.rotation;

        // Attach Scripts

        MovementInput movementInputScript = target.AddComponent<MovementInput>() as MovementInput;
        ActionInput actionInputScript = target.AddComponent<ActionInput>() as ActionInput;
        actionInputScript.Initialize();
        CharacterTransfer characterTransferScript = target.AddComponent<CharacterTransfer>() as CharacterTransfer;
        actionInputScript.Initialize();
        Destroy(gameObject);
    }
}
