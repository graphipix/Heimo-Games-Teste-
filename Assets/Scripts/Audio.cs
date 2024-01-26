using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioSource Sound;
    public AudioClip idle, moving;
    public TurningCar turningscript = default;

    private void Update()
    {
        if (turningscript.velocity <= 20 && Sound.clip != idle)
        {
            Sound.clip = idle;
            Sound.Play();
        }

        if (turningscript.velocity > 20 && Sound.clip != moving)
        {
            Sound.clip = moving;
            Sound.Play();
        }

    }
}
