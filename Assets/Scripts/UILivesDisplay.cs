using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILivesDisplay : UITextDisplay
{
    public int livesRemaining;
    // Update is called once per frame
    void Update()
    {
        text.text = string.Format("Lives: " + livesRemaining);
    }
}
