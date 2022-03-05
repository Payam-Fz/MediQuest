using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private int targetScene = 1; //MainSection

    // private void Awake() {
    //     if (Instance == null) {
    //         Instance = this;
    //     } else if (Instance != this) {
    //         Destroy(gameObject);
    //     }
    // }

    public void DelayedLoadFirstScene(float delayDuration)
   {
       this.targetScene = 1;  
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
        Application.Quit();
    }
}
