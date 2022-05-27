using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTransfer : MonoBehaviour
{
    private bool transferActive = false;
    private void Update()
    {
        //Transfer();
        transferActive = false;
        if (Input.GetMouseButtonDown(0))
        {
            transferActive = true;
        }
    }

    private void FixedUpdate()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            //Debug.Log("Did Hit");
            if (transferActive)
            {
                Debug.Log("Did Transfer");
                //if (hit.rigidbody != null)
                //{
                //    Transfer(hit);
                //}
                Transfer(hit);
            }
        }
        else
        {
           // Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            //Debug.Log("Did not Hit");
        }
    }
    private void Transfer(RaycastHit hit)
    {
        Debug.Log(hit.rigidbody);

        // Get Gameobject
        GameObject target = hit.transform.gameObject;

        // Update Tags
        target.tag = "Player";

        // Remove Script

        MovementInputAI movementInputScriptAI = target.GetComponent<MovementInputAI>() as MovementInputAI;
        Destroy(movementInputScriptAI);

        // Attach Scripts
        MovementInput movementInputScript = target.AddComponent<MovementInput>() as MovementInput;
        CameraController cameraScript = target.AddComponent<CameraController>() as CameraController;
        CharacterTransfer characterTransferScript = target.AddComponent<CharacterTransfer>() as CharacterTransfer;

        // Place Camera
        GameObject targetCameraPivot = target.transform.GetChild(0).gameObject;
        Camera camera = Camera.main;
        camera.transform.SetParent(targetCameraPivot.transform);
        camera.transform.position = target.transform.position;
        Destroy(gameObject);
    }
}
