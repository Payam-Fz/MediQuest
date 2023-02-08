using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockMachineInteractManager : MonoBehaviour, IInteractable
{
    SpriteRenderer clockSprite;
    [SerializeField] Sprite clockOffline;
    [SerializeField] Sprite clockGreen;
    [SerializeField] Sprite clockRed;
    bool pauseShowing = false;
    bool beginning = true;
    [SerializeField] GameObject clockMenuCanvas;

    // Start is called before the first frame update
    void Start()
    {
        clockSprite = GetComponent<SpriteRenderer>();
    }

    //set color to red when player returns to the machine during game/ turns offline when leaving the machine
    public void Interact()
    {
        if (!pauseShowing)
        {
            clockMenuCanvas.SetActive(true);
            pauseShowing = true;
        }
        else
        {
            clockMenuCanvas.SetActive(false);
            pauseShowing = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Player is at the clock machine");
        if (collision.tag == "Player")
        {
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
        Debug.Log("Player is outside the clock machine");
        clockSprite.sprite = clockOffline;
    }

    public void ManualHighlight()
    {
        //throw new System.NotImplementedException();
        Debug.Log("Clock Highlight is not implemented.");
    }

}
