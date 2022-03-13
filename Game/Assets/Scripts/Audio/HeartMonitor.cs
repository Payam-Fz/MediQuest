using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartMonitor : MonoBehaviour, IAudioObject
{
    [SerializeField] AudioSource ECGSound;

    private void Start()
    {
        ECGSound = GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
        ECGSound.Play();
    }

    public void StopSound()
    {
        ECGSound.Stop();
    }

}
