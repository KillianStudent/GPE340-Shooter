using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupHealth : Pickup
{
    [SerializeField] private float healingDone;

    public override void Update()
    {
        Spin();
    }

    public override void OnTriggerEnter(Collider collider)
    {
        Pawn pawn = collider.GetComponent<Pawn>();
        if (pawn)
        {
            OnPickUp(pawn);
        }
    }

    public override void OnPickUp(Pawn pawn)
    {
        pawn.GetComponent<Health>().gainHealth(healingDone);
        Destroy(gameObject);
    }
}
