using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerController : MonoBehaviour
{
    [SerializeField] private Text HealthPointsText;
    [SerializeField] private Text SoulFragmentsText;

    [SerializeField] private PlayerStats player;

    private void Update()
    {
        UpdateHealthPointsText();
        UpdateSoulFragmentsText();
    }
    private void UpdateHealthPointsText()
    {
        HealthPointsText.text = player.playerHealthPoints.ToString();
    }

    private void UpdateSoulFragmentsText()
    {
        SoulFragmentsText.text = player.playerSoulFragments.ToString();
    }
}
