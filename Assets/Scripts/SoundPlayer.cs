using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public void PlaySound(AudioClip soundToPlay)
    {
        this.GetComponent<AudioSource>().clip = soundToPlay;
        this.GetComponent<AudioSource>().Play();
    }
}
