using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public void Back() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void MasterSlider(float value) {
        audioMixer.SetFloat("MasterVolume", value);
    }

    public void MusicSlider(float value) {
        audioMixer.SetFloat("MusicVolume", value);
    }

    public void SFXSlider(float value) {
        audioMixer.SetFloat("SFXVolume", value);
    }
}
