using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private int targetScene = 1; //MainSection

    public void DelayedLoadFirstScene(float delayDuration)
    {
        this.targetScene = 1;
        SaveLoadSystem.LoadAllData();
        Invoke("Load", delayDuration);
    }

    public void LoadScene(int targetScene)
    {
        this.targetScene = targetScene;
        Load();
    }

    private void Load()
    {
        SceneManager.LoadScene(targetScene);
    }

    public void QuitGame()
    {
        SaveLoadSystem.SaveAllData();
        Application.Quit();
    }
}
