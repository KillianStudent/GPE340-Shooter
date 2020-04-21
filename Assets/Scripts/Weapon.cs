<<<<<<< Updated upstream
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected float damageDone;
    public Transform RighthandPoint;
    public Transform LefthandPoint;
    
    // Start is called before the first frame update
    public abstract void Start();

    // Update is called once per frame
    public abstract void Update();

    public abstract void OnTriggerPull();

    public abstract void OnTriggerRelease();

}
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected float damageDone;
    public Transform RighthandPoint;
    public Transform LefthandPoint;
    
    // Start is called before the first frame update
    public abstract void Start();

    // Update is called once per frame
    public abstract void Update();

    public abstract void OnTriggerPull();

    public abstract void OnTriggerRelease();

}
>>>>>>> Stashed changes
