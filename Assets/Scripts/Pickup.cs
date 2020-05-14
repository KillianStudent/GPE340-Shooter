using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    // Update is called once per frame
    public virtual void Update()
    {
 
    }
    
    public abstract void OnTriggerEnter(Collider collider);

    public virtual void OnPickUp(Pawn pawn)
    {
        {
            Destroy(this.gameObject);   // all pickups destroy themselves on pickup
        }
    }

    public virtual void Spin()
    {
        if (Time.timeScale == 0)
        {
            transform.Rotate(0, 0, 0);
        }
        else
        {
            transform.Rotate(0, 5, 0);
        }
    }
}
