using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerController : MonoBehaviour
{
    [SerializeField] private Text HealthPointsText;
    [SerializeField] private Text SoulFragmentsText;
    [SerializeField] private Text ScoreText;

    [SerializeField] private PlayerStats player;

    private void Update()
    {
        UpdateHealthPointsText();
        UpdateSoulFragmentsText();
        UpdateScoreText();
    }
    private void UpdateHealthPointsText()
    {
        HealthPointsText.text = "Health: " + player.playerHealthPoints.ToString();
    }

    private void UpdateSoulFragmentsText()
    {
        SoulFragmentsText.text = player.playerSoulFragments.ToString();
    }
    private void UpdateScoreText()
    {
        ScoreText.text = "Score: " + player.playerScore.ToString();
    }
}
