using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionInputAI : MonoBehaviour
{
    private void Update()
    {
        ActionShoot Script = GetComponent<ActionShoot>();
        Script.SpawnProjectile();
    }
}

