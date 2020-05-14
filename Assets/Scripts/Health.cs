using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [Header("Events")]  // tooltip events for displaying particles or sounds for later
    [SerializeField, Tooltip("Raised every time the object is healed")]
    private UnityEvent onHeal;
    [SerializeField, Tooltip("Raised every time the object is damaged.")]
    private UnityEvent onDamage;
    [SerializeField, Tooltip("Raised once when the object's health reaches 0.")]
    public UnityEvent onDie;

    [SerializeField] private float maxHP = 100;   // max HP, base value of 100
    [SerializeField] private float currentHP;   // the HP at a current moment
    public float HP { get { return currentHP; } set { currentHP = value; if (currentHP > maxHP) { currentHP = maxHP; } } }  // currentHP getter and setter
    public float percentHP { get { return currentHP / maxHP; } }    // percentage of HP getter for displaying on the UI
    void Start()    // sets the currentHP to maxHP on startup so it spawns with full HP
    {
        currentHP = maxHP;
    }

    public void gainHealth(float value)
    {
        HP += value;
        onHeal.Invoke();
    }

    public void loseHealth(float value)
    {
        HP -= value;
        onDamage.Invoke();
        checkDie();
    }

    public void checkDie()
    {
        if (HP <= 0)
        {
            onDie.Invoke();
            if (this.gameObject.tag == "Player")
            {
                Destroy(this.gameObject, 3);
            }
            else
            {
                Destroy(this.gameObject, 7);
            }
        }
        else
        {

        }
    }
}