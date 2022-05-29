using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PlayerStats", order = 2)]
public class PlayerStats : ScriptableObject
{
    public int playerHealthPoints;
    public int playerSoulFragments;

    public int playerScore;

    public PlayerStats()
    {
        playerHealthPoints = 100;
        playerSoulFragments = 3;

        playerScore = 0;
    }

    public void UpdatePlayerHealthPoints(int healthPoints)
    {
        playerHealthPoints = healthPoints;
    }

    public void UpdatePlayerSoulFragments(int soulFragments)
    {
        playerSoulFragments = soulFragments;
    }

    public void UpdatePlayerScore(int score)
    {
        playerScore = score;
    }
}

