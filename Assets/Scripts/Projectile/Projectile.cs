using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float projectileVelocity;
    [SerializeField] private float projectileGravity;
    [SerializeField] private float projectileLifeTime;

    [SerializeField] private PlayerStats player;

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * projectileVelocity);
    }
    // Update is called once per frame
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
        Debug.Log(other.gameObject.tag);
        if(other.gameObject.tag == "Enemy")
        {
            // SetObject property
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "Player")
        {
            player.UpdatePlayerHealthPoints(player.playerHealthPoints - 35);
        }
        //Animation?
        Destroy(gameObject);
    }
}
