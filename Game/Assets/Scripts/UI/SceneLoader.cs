using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    
   public void LoadGameScene()
    {
        Invoke("Load", 3.0f);
    }

    private void Load()
    {
        SceneManager.LoadScene(1);
    } 

    public void QuitGame()
    {
        Application.Quit();
    }
}
