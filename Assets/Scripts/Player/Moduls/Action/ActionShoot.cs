using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionShoot : MonoBehaviour, ICharacterAction 
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float projectileVelocity;
    public void SpawnProjectile()
    {
        GameObject ball = Instantiate(projectilePrefab, transform.position, transform.rotation);
        ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, projectileVelocity, 0));
    }

    void Update()
    {
        
    }
}
