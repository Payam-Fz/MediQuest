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
    bool beginning = true;
    [SerializeField] GameObject tempNPC;
    ClockMenu clockMenu;

    // Start is called before the first frame update
    void Start()
    {
        clockSprite = GetComponent<SpriteRenderer>();
    }

    //set color to red when player returns to the machine during game/ turns offline when leaving the machine
    public void Interact()
    {
        if (clockSprite.sprite == clockOffline)
        {
            if (beginning)
            {
                clockSprite.sprite = clockGreen;
                beginning = false;
            } else
            {
                clockSprite.sprite = clockRed;
            }
            tempNPC.transform.localScale = new Vector3(1, 1, 1);
            if (playerPresent)
            {
                clockMenu.pause();
            }
        }
        else if (clockSprite.sprite == clockGreen || clockSprite.sprite == clockRed)
        {
            clockSprite.sprite = clockOffline;
            clockMenu.resume();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Player is at the clock machine");
        if (collision.tag == "PlayerTag")
        {
            playerPresent = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "PlayerTag")
        {
            playerPresent = false;
        }
    }

    public void ManualHighlight()
    {
        //throw new System.NotImplementedException();
        Debug.Log("Clock Highlight is not implemented.");
    }

}
