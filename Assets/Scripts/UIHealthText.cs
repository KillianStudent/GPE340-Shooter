using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Text))]

public class UIHealthText : MonoBehaviour
{
    private Text text;

    private Health pawnHealth;

    public GameObject pawn;

    private void Awake()
    {
        pawnHealth = pawn.GetComponent<Health>();
        text = GetComponent<Text>();
    }


    // Update is called once per frame
    void Update()
    {
        text.text = string.Format("Health: " +  Mathf.RoundToInt(pawnHealth.percentHP * 100f) + "%");
    }
}
