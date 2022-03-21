using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public bool loadData = false;
    public float delayDuration = 2f;
    public CharacterInfo customizedPlayer;

    public void DelayedLoadFirstScene()
    {
        SaveLoadSystem.LoadAllData();
        Invoke("InitialLoadWithData", delayDuration);
    }

    public void LoadScene(int targetScene)
    {
        SceneManager.LoadScene(targetScene);
    }

    private void InitialLoadWithData()
    {
        SceneManager.LoadScene(1);
        if (loadData)
        {
            SaveLoadSystem.LoadAllData();
        } else
        {
            
            if (customizedPlayer != null)
            {
                PlayerData playerData = new PlayerData(customizedPlayer);
                playerData.LoadToObject();
            } else
            {
                Debug.LogError("Could not load customization data");
                return;
            }
        }
    }

    public void QuitGame()
    {
        SaveLoadSystem.SaveAllData();
        Application.Quit();
    }
}
