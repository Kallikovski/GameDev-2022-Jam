using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private static PlayerStats instance = null;

    [SerializeField] private int soulFragments;
    [SerializeField] private int healthPoints;
    [SerializeField] private GameManager gameManager;
    private int currentSoulFragments { get; set; }
    private int currentHealthPoints { get; set; }

    private PlayerStats()
    {
    }

    public static PlayerStats Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new PlayerStats();
            }
            return instance;
        }
    }
    private void Start()
    {
        gameManager.onGameStateChange += SetStartValues;
    }

    // Update is called once per frame
    private void Update()
    {
        if (currentHealthPoints == 0)
        {
            //Soul transfere state?
        }
        if (currentHealthPoints == 0 && currentSoulFragments == 0)
        {
            UpdateGameState(GameManager.State.End);
        }
    }

    private void UpdateGameState(GameManager.State state)
    {
        gameManager.UpdateGameState(state);
    }

    private void SetStartValues(GameManager.State state)
    {
        if (state == GameManager.State.Start)
        {
            currentHealthPoints = healthPoints;
            currentSoulFragments = soulFragments;
        }
    }
}
