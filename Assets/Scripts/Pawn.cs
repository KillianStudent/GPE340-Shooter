using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("crouch");
            anim.SetBool("Crouching", true);
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            Debug.Log("Uncrouch");
            anim.SetBool("Crouching", false);
        }
    }

    public void Move(Vector3 directionToMove)
    {
        directionToMove = transform.InverseTransformDirection(directionToMove);
        directionToMove = Vector3.ClampMagnitude(directionToMove, 1);
        anim.SetFloat("Forward", directionToMove.z * speed);
        anim.SetFloat("Right", directionToMove.x * speed);
    }
}
