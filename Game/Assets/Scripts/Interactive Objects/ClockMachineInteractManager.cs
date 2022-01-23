using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockMachineInteractManager : MonoBehaviour, IInteractable
{
    SpriteRenderer clockSprite;
    [SerializeField] Sprite clockOn;
    [SerializeField] Sprite clockOff;
    bool playerPresent;



    // Start is called before the first frame update
    void Start()
    {
        clockSprite = GetComponent<SpriteRenderer>();
        
    }

    public void Interact()
    {
        if (clockSprite.sprite == clockOff)
        {
            clockSprite.sprite = clockOn;
            if (playerPresent)
            {
                //
            }
        }
        else if (clockSprite.sprite == clockOn)
        {
            clockSprite.sprite = clockOff;
            //
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Player is at the clock machine");

        if (collision.tag == "PlayerTag")
        {
            playerPresent = true;
            if (clockSprite.sprite == clockOn)
            {
                //
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "PlayerTag")
        {
            playerPresent = false;
            //
        }
    }

    public void ManualHighlight()
    {
        //throw new System.NotImplementedException();
        Debug.Log("Clock Highlight is not implemented.");
    }

}
