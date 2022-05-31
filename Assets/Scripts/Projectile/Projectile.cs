using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float projectileVelocity;
    [SerializeField] private int projectileDamage;
    [SerializeField] private float projectileLifeTime;

    [SerializeField] private PlayerStats player;

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * projectileVelocity);
    }
    private void Update()
    {
        projectileLifeTime -= Time.deltaTime;
        if(projectileLifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            // SetObject property
            if(gameObject.tag == other.gameObject.tag)
            {
                Destroy(gameObject);
            }
            player.playerScore += 10;
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "Player")
        {
            if(gameObject.tag == other.gameObject.tag)
            {
                Destroy(gameObject);
            }
            if(gameObject.tag == "Enemy")
            {
                player.UpdatePlayerHealthPoints(player.playerHealthPoints - 35);
            }
        }
        Destroy(gameObject);
    }
}
