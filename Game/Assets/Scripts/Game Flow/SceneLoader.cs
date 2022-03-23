using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public bool loadData = false;
    public float delayDuration = 2f;
    //public CharacterInfo customizedPlayer;

    public void DelayedLoadFirstScene(bool loadData = false)
    {
        this.loadData = loadData;
        Invoke("InitialLoadWithData", delayDuration);
    }

    public void LoadScene(int targetScene)
    {
        if (targetScene == 0)
        {
            SaveLoadSystem.SaveAllData();
        }
        SceneManager.LoadScene(targetScene);
    }

    private void InitialLoadWithData()
    {
        SceneManager.LoadScene(1);
        if (loadData)
        {
            SaveLoadSystem.LoadAllData();
        }
    }

    public void QuitGame(bool saveData)
    {
        if (saveData)
        {
            try
            {
                SaveLoadSystem.SaveAllData();
            } catch(NullReferenceException ex)
            {
                Debug.LogError("Couldn't save before exit. Make sure you are calling QuitGame in the scene");
            }
        }
        
        Application.Quit();
    }
}
