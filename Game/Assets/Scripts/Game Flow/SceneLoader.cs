using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    //public bool loadData = false;
    public float delayDuration = 2f;
    //public CharacterInfo customizedPlayer;

    public void DelayedLoadFirstScene(bool loadData = false)
    {
        //this.loadData = loadData;
        if (loadData)
        {
            SaveLoadSystem.LoadAllData();
        }
        //Invoke("LoadScene", delayDuration);
        StartCoroutine(DelayedLoadScene(1));
    }

    //public void LoadScene(int targetScene = 1)
    //{
    //    if (targetScene == 0)
    //    {
    //        SaveLoadSystem.SaveAllData();
    //    }
    //    SceneManager.LoadScene(targetScene);
    //}

    IEnumerator DelayedLoadScene(int targetScene)
    {
        yield return new WaitForSeconds(delayDuration);
        if (targetScene == 0)
        {
            SaveLoadSystem.SaveAllData();
        }
        SceneManager.LoadScene(targetScene);
    }

    public void LoadScene(int targetScene)
    {
        if (targetScene == 0)
        {
            SaveLoadSystem.SaveAllData();
        }
        SceneManager.LoadScene(targetScene);
    }

    //private void InitialLoadWithData()
    //{
    //    SceneManager.LoadScene(1);

    //}

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
