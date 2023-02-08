using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Handles the game clock menu
 * Author:  Kenny A @ 2022-01-22
 */

public class ClockMenu : MonoBehaviour
{
    public GameObject clockMenuUI;
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

    // loadPauseMenu sets the pause menu UI panel to true, making it show in game, and sets the 
    // time scale to 0, which pauses the game. We then update the gameIsPaused variable to true.
    public void pause()
    {
        clockMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    // hidePauseMenu sets the pause menu UI panel to false, hiding the panel from the player, resumes 
    // the game by setting the time scale to 1, and updates the gameIsPaused variable to false.
    public void resume()
    {
        clockMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
}
