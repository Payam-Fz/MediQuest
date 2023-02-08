using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UIElements;

public class SettingsMenu : MonoBehaviour
{
    public GameObject mainMenuHolder;
    public GameObject optionsMenuHolder;
    public Slider[] volumeSliders;
    public Toggle[] resolutionToggles;
    public int[] screenWidths;

    public AudioMixer audioMixer;


    public void OptionsMenu() {
        mainMenuHolder.SetActive (false);
        optionsMenuHolder.SetActive (true);
    }

    public void PauseMenu() {
        mainMenuHolder.SetActive (true);
        optionsMenuHolder.SetActive (false);
    }

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

    public void SetScreenResolution(int i) {

    }

    public void SetFullScreen(bool isFullScreen) {

    }
}
