using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerController : MonoBehaviour
{
    [SerializeField] private Text HealthPointsText;
    [SerializeField] private Text SoulFragmentsText;

    [SerializeField] private PlayerStats PlayerStats;
    // Start is called before the first frame update
    private void Awake()
    {
        PlayerStats = PlayerStats.Instance;
    }

    private void UpdateHealthPointsText()
    {
        //
    }

    private void UpdateSoulFragmentsText()
    {
        //
    }
}
