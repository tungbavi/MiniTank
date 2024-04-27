using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    public AudioClip shootSound;
    public AudioClip explosionTankSound;
    public AudioClip explosionShellSound;
    public AudioClip backgroundSound;
    public AudioSource audioSource;
}
