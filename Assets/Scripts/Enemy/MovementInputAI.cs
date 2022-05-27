using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementInputAI : MonoBehaviour
{
    private Transform playerPosition;
    [SerializeField] private float distanceToPlayer;

    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 moveDirection = new Vector3(0f, 0f, 0f);
        playerPosition = GameObject.FindWithTag("Player").transform;
        Vector3 distanceVector = playerPosition.position - transform.position;
        MoveVelocity Script = GetComponent<MoveVelocity>();
        if(distanceVector.magnitude > distanceToPlayer)
        {
            moveDirection = (playerPosition.position - transform.position).normalized;
        }
        //transform.LookAt(playerPosition);
        Script.SetVelocity(moveDirection);
    }


}
