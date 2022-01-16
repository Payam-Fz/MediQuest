using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    public void Back() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void MasterSlider(float value) {

    }

    public void MusicSlider(float value) {

    }

    public void SFXSlider(float value) {

    }
}
