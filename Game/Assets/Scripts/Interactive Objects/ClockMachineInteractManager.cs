using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockMachineInteractManager : MonoBehaviour, IInteractable
{
    SpriteRenderer clockSprite;
    [SerializeField] Sprite clockOffline;
    [SerializeField] Sprite clockGreen;
    [SerializeField] Sprite clockRed;
    bool playerPresent;
    bool pauseShowing = false;
    bool beginning = true;
    [SerializeField] ClockMenu clockMenu;

    // Start is called before the first frame update
    void Start()
    {
        clockSprite = GetComponent<SpriteRenderer>();
    }

    //void Awake()
    //{
    //    if (beginning)
    //    {
    //        clockSprite.sprite = clockGreen;
    //        beginning = false;
    //    }
    //}

    //set color to red when player returns to the machine during game/ turns offline when leaving the machine
    public void Interact()
    {
        if (playerPresent)
        {
            if (!pauseShowing)
            {
                clockMenu.pause();
                pauseShowing = true;
            } else
            {
                clockMenu.resume();
                pauseShowing = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Player is at the clock machine");
        if (collision.tag == "PlayerTag")
        {
            playerPresent = true;
            if (beginning)
            {
                clockSprite.sprite = clockGreen;
                beginning = false;
            } else
            {
                clockSprite.sprite = clockRed;
            }
        } 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "PlayerTag")
        {
            playerPresent = false;
        }
     
        clockSprite.sprite = clockOffline;
    }

    public void ManualHighlight()
    {
        //throw new System.NotImplementedException();
        Debug.Log("Clock Highlight is not implemented.");
    }

}
