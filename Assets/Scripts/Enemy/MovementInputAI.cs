using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementInputAI : MonoBehaviour
{
    private Transform playerPosition;
    [SerializeField] private float distanceToPlayer;
    public GameManager gameManager;
    public bool getInput;

    private void Awake()
    {
        getInput = true;
        gameManager.onGameStateChange += updateGetInput;
    }

    // Update is called once per frame
    private void Update()
    {

        Vector3 moveDirection = new Vector3(0f, 0f, 0f);
        playerPosition = GameObject.FindWithTag("Player").transform;
        Vector3 distanceVector = playerPosition.position - transform.position;
        MoveVelocity Script = GetComponent<MoveVelocity>();
        if (getInput)
        {
            if (distanceVector.magnitude > distanceToPlayer)
            {
                moveDirection = (playerPosition.position - transform.position).normalized;
            }
        }
        else
        {
            moveDirection = new Vector3(0f, 0f, 0f);
        }
        transform.LookAt(playerPosition.position);
        Script.SetVelocity(moveDirection);
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
