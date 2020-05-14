using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletData : MonoBehaviour
{
    public float damageDone;
    public float moveSpeed;
    [SerializeField] private float lifespan = 2.0f;

    public void Start()
    {
        Destroy(gameObject, lifespan);
    }

    public void Update()
    {
        // move forward
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    public void OnCollisionEnter(Collision other)
    {
        Health otherHealth = other.gameObject.GetComponent<Health>();
        if (otherHealth != null)
        {
            otherHealth.loseHealth(damageDone);
        }
        Destroy(gameObject);
    }


}