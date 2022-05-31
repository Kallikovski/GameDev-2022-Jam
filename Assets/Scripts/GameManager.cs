using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameManager", order = 1)]
public class GameManager : ScriptableObject
{
    public enum State { Start, Running, Transfer, Pause, End};

    public State currentState;

    public GameManager()
    {
        UpdateGameState(State.Start);
    }

    public event Action<State> onGameStateChange;

    public void UpdateGameState(State state)
    {
        if(onGameStateChange != null)
        {
            currentState = state;
            onGameStateChange(currentState);
            if(currentState == State.Running)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
    
}
