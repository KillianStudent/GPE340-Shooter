using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPawn : Pawn
{
    public Weapon[] defaultWeapons;
    public AIController aiController;
    public float aiRange = 1f; // the field of view in which the AI will be able to shoot the player

    new void Start()
    {
        base.Start();
        aiController.GetComponent<AIController>().pawns.Add(GetComponent<Pawn>()); // when spawning adds the enemy's pawn script to the list of pawns in AIController
        EquipWeapon(defaultWeapons[Random.Range(0, defaultWeapons.Length)]);
    }

    private void OnAnimatorMove()
    {
        if (agent != null)
        {
            agent.velocity = anim.velocity;
        }
    }

    public void removeFromController()  // removes self from the aiController's pawn list, disabling its movement to the player
    {
        aiController.GetComponent<AIController>().pawns.Remove(this.GetComponent<Pawn>());
    }

    public void Update()
    {
        if (Vector3.Distance(this.transform.position, aiController.target.transform.position) < aiRange)
        {
            weapon.OnTriggerPull();
        }
    }

    public bool isInRange()
    {


        return false;
    }
}
