using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float projectileVelocity;
    [SerializeField] private float projectileGravity;
    [SerializeField] private float projectileLifeTime;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * projectileVelocity);
    }

    private void FixedUpdate()
    {
        //rb.AddForce(new Vector3(0, -1.0f, 0) * rb.mass * (projectileGravity - 9.81f));
        //rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, projectileVelocity);
    }
    // Update is called once per frame
    private void Update()
    {
        Debug.Log(rb.velocity);
        projectileLifeTime -= Time.deltaTime;
        if(projectileLifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
