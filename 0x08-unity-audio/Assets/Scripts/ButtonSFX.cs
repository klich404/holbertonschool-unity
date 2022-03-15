using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSFX : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;

    void Start()
    {
        source.clip = clip;
    }

    public void PlaySound()
    {
        source.PlayOneShot(clip);
    }
}
