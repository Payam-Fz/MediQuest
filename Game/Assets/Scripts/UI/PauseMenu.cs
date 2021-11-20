using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Handles the game pause menu
 * Author:  Kenny A @ 2021-11-06
 */
public class PauseMenu : MonoBehaviour
{
   GameObject[] pauseObjects;

   // Start is called before the first frame update
   void Start()
    {
        // If the time scale is at 0, the game is paused
        // If the time scale is greater than 0, the game is un-paused
        Time.timeScale = 1; 
        pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
        hidePauseMenu();
        
    }

    // Update is called once per frame
    void Update()
    {
        // Uses the p button to pause and unpause the game
        if(Input.GetKeyDown(KeyCode.P)) {
            if(Time.timeScale == 1) {
                Time.timeScale = 0;
                loadPauseMenu();
            } else if (Time.timeScale == 0) {
                Debug.Log("high");
                Time.timeScale = 1;
                hidePauseMenu();
            }
        }
        
    }

    public void loadPauseMenu() {
        foreach(GameObject i in pauseObjects) {
            i.SetActive(true);
        }
    }

    public void hidePauseMenu() {
        foreach(GameObject i in pauseObjects) {
             i.SetActive(false);
        }
    }
}
