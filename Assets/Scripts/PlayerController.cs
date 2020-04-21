<<<<<<< Updated upstream
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public override void Update()
    {
        HandleMovement();
        HandleShooting();
    }

    private void HandleShooting()
    {
        if (Input.GetButtonDown("Fire"))
        {
            pawn.OnTriggerPull.Invoke();
        }

        if (Input.GetButtonUp("Fire"))
        {
            pawn.OnTriggerRelease.Invoke();
        }
    }

    private void HandleMovement()
    {
        // Handle Movement
        Vector3 moveVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        pawn.Move(moveVector);
    }
}
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public override void Update()
    {
        HandleMovement();
        HandleShooting();
    }

    private void HandleShooting()
    {
        if (Input.GetButtonDown("Fire"))
        {
            pawn.OnTriggerPull.Invoke();
        }

        if (Input.GetButtonUp("Fire"))
        {
            pawn.OnTriggerRelease.Invoke();
        }
    }

    private void HandleMovement()
    {
        // Handle Movement
        Vector3 moveVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        pawn.Move(moveVector);
    }
}
>>>>>>> Stashed changes
