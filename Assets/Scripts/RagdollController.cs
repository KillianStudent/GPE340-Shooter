using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
    private Rigidbody mainRigidbody;
    private Collider mainCollider;
    private Rigidbody[] childRigidbodies;
    private Collider[] childColliders;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        mainRigidbody = GetComponent<Rigidbody>();
        mainCollider = GetComponent<Collider>();

        childRigidbodies = GetComponentsInChildren<Rigidbody>();
        childColliders = GetComponentsInChildren<Collider>();

        anim = GetComponent<Animator>();

        DisableRagdoll();
    }

    public void DisableRagdoll() // disables the ragdoll when it is alive
    {
        foreach (Collider col in childColliders)
        {
            col.enabled = false;
        }

        foreach (Rigidbody rb in childRigidbodies)
        {
            rb.isKinematic = true;
        }

        mainRigidbody.isKinematic = false;
        mainCollider.enabled = true;
        anim.enabled = true;
    }

    public void EnableRagdoll() // enables the ragdoll, called on death
    {
        foreach (Collider col in childColliders)
        {
            col.enabled = true;
        }
        foreach (Rigidbody rb in childRigidbodies)
        {
            rb.isKinematic = false;
        }

        mainRigidbody.isKinematic = true;
        mainCollider.enabled = false;
        anim.enabled = false;
    }
}
