using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameManager", order = 1)]
public class GameManager : ScriptableObject
{
    public enum State { Start, Running, Pause, End};

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
            if(currentState != State.Running)
            {
                //Time.timeScale = 0.0f;
            }
            else
            {
                //Time.timeScale = 1.0f;
            }
            onGameStateChange(currentState);
        }
    }
    
}
