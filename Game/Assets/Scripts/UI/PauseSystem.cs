using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/*
 * Handles the game pause menu
 * Author:  Kenny A @ 2021-11-06
 */

public class PauseSystem : MonoBehaviour
{
   public GameObject pauseMenuUI;
   public bool gameIsPaused = false;
   // making a public gameIsPaused allows other scripts to run functions depending on 
   // whether the game is pause.

   // Start is called before the first frame update
   void Start()
    {
        // If the time scale is at 0, the game is paused
        // If the time scale is greater than 0, the game is un-paused
        Time.timeScale = 1; 
        resume();
    }

    // Update is called once per frame
    void Update()
    {
        // Uses the Escape button to pause and unpause the game
        if(Input.GetKeyDown(KeyCode.Escape)) {
            Debug.Log("Escape key was pressed");
            if(Time.timeScale == 1) {
                pause();
            } else if (Time.timeScale == 0) {
                resume();
            }
        }
        
    }

// loadPauseMenu sets the pause menu UI panel to true, making it show in game, and sets the 
// time scale to 0, which pauses the game. We then update the gameIsPaused variable to true.
    public void pause() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

// hidePauseMenu sets the pause menu UI panel to false, hiding the panel from the player, resumes 
// the game by setting the time scale to 1, and updates the gameIsPaused variable to false.
    public void resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    // public void loadMenu() {
    //     Time.timeScale = 1f;
    //     SceneManager.LoadScene("Menu");
    // }

    // public void quitGame() {
    //     Debug.Log("quitting game...");
    //     Application.Quit();
    // }
}
