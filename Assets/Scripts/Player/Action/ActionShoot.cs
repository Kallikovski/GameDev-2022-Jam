using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionShoot : MonoBehaviour, ICharacterAction 
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform projectileSpawn;
    [SerializeField] private float actionCooldown;

    private float lastActionTimeAgo = 0;
    private bool canShoot;
    private void Update()
    {
        lastActionTimeAgo += Time.deltaTime;
        if(lastActionTimeAgo >= actionCooldown)
        {
            canShoot = true;
        }
        else
        {
            canShoot = false;
        }
    }
    public void SpawnProjectile()
    {
        if (canShoot)
        {
            GameObject projectile = Instantiate(projectilePrefab, projectileSpawn.position, projectileSpawn.rotation);
            projectile.tag = gameObject.tag;
            lastActionTimeAgo = 0;
        }
    }
}
