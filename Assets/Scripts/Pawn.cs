using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; // for the weapon
using UnityEngine.AI;

public class Pawn : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;

    public Weapon weapon;
    public UnityEvent OnTriggerPull;
    public UnityEvent OnTriggerRelease;
    public Transform aimPoint;

    public Animator anim;
    public NavMeshAgent agent;

    [SerializeField]private WeaponAnimationType animationType = WeaponAnimationType.None;

    public enum WeaponAnimationType
    {
        None = 0,
        Rifle = 1,
        Pistol = 2,
    }

    // Start is called before the first frame update
    public void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    public void OnAnimatorIK()  // IKhandler, for left and right hand positions
    {
        if (weapon == null)
        {
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 0.0f);
            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0.0f);
            anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 0.0f);
            anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0.0f);

            // exit
            return;
        }
        if (weapon.RighthandPoint != null)
        {
            Debug.Log("IK-right-animating");
            anim.SetIKPosition(AvatarIKGoal.RightHand, weapon.RighthandPoint.position);
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1.0f);
            anim.SetIKRotation(AvatarIKGoal.RightHand, weapon.RighthandPoint.rotation);
            anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 1.0f);
        }
        else
        {
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 0.0f);
            anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 0.0f);
        }

        if (weapon.LefthandPoint != null)
        {
            Debug.Log("IK-left-animating");
            anim.SetIKPosition(AvatarIKGoal.LeftHand, weapon.LefthandPoint.position);
            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1.0f);
            anim.SetIKRotation(AvatarIKGoal.LeftHand, weapon.LefthandPoint.rotation);
            anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1.0f);
        }
        else
        {
            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0.0f);
            anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0.0f);
        }
    }

    public void EquipWeapon(Weapon _weapon) 
    {
        if (weapon != null) // checks if there is a weapon already, if there is then it unequips it
        {
            Unequip();
        }
        weapon = Instantiate(_weapon.GetComponent<Weapon>()) as Weapon;


        weapon.transform.localPosition = aimPoint.transform.position;
        weapon.transform.localRotation = aimPoint.transform.rotation;
        weapon.transform.SetParent(aimPoint);

        animationType = WeaponAnimationType.Rifle;
        anim.SetInteger("Weapon Animation Type", ((int)animationType));

        OnTriggerPull.AddListener(weapon.OnTriggerPull);
        OnTriggerRelease.AddListener(weapon.OnTriggerRelease);
    }

    // checks if the C key is entered, if it is then the animator uses crouching animations, when released it reverts back to standing
    void Update()
    {
        if (this.gameObject.tag == "Player")
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
    }

    public void Unequip()   // unequips a weapon if it's equipped
    {
        Destroy(weapon.gameObject);
        OnTriggerPull.RemoveListener(weapon.OnTriggerPull);
        OnTriggerRelease.RemoveListener(weapon.OnTriggerRelease);
    }

    public void Move(Vector3 directionToMove)
    {
        directionToMove = transform.InverseTransformDirection(directionToMove);
        directionToMove = Vector3.ClampMagnitude(directionToMove, 1);
        anim.SetFloat("Forward", directionToMove.z * speed);
        anim.SetFloat("Right", directionToMove.x * speed);
    }
}