using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : Controller
{
    public List<Pawn> pawns;
    public Transform target;

    // Start is called before the first frame update
    public override void Start()
    {
    }

    // Update is called once per frame
    public override void Update()
    {
        foreach (Pawn _pawn in pawns)
        {
            _pawn.agent.SetDestination(target.position);
            Vector3 desiredMovement = _pawn.agent.desiredVelocity;
            _pawn.Move(desiredMovement);
        }
    }

    public void nullifyTarget()
    {
        target = null;
    }
}
