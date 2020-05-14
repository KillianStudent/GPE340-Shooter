using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PIckupWeapon : Pickup
{
    public Weapon weaponToSpawn;

    public override void Update()
    {
        Spin();
    }

    public override void OnTriggerEnter(Collider collider)
    {
        Pawn pawn = collider.GetComponent<Pawn>();
        OnPickUp(pawn);
    }

    public override void OnPickUp(Pawn pawn)    // destroys itself 
    {
        Pawn targetPawn = pawn.GetComponent<Pawn>();
        if (pawn != null)
        {
            pawn.EquipWeapon(weaponToSpawn);        
            Destroy(gameObject);
        }
    }
}
