using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionInput : MonoBehaviour
{
    void Update()
    {
        ActionShoot Script = GetComponent<ActionShoot>();
        if (Input.GetMouseButtonDown(0))
        {
            Script.SpawnProjectile();
        }
    }
}
