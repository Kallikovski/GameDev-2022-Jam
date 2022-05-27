using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float projectileVelocity;
    [SerializeField] private float projectileGravity;
    [SerializeField] private float projectileLifeTime;

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
        }
        if(other.gameObject.tag == "Player")
        {
            // update scriptable Object PlayerStats
        }
        //Animation?
        Destroy(gameObject);
    }
}
