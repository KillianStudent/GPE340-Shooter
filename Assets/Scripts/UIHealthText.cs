using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthText : UITextDisplay
{
    public Health pawnHealth;

    // Update is called once per frame
    void Update()
    {
        text.text = string.Format("Health: " +  Mathf.RoundToInt(pawnHealth.percentHP * 100f) + "%");
    }
}
