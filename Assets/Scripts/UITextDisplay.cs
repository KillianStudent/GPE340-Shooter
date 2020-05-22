using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITextDisplay : MonoBehaviour
{
    public Text text;

    private void Awake()
    {
        text = GetComponent<Text>();
    }
}
