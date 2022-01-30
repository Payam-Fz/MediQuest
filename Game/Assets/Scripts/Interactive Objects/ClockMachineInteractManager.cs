using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockMachineInteractManager : MonoBehaviour, IInteractable
{
    SpriteRenderer clockSprite;
    [SerializeField] Sprite clockOn;
    [SerializeField] Sprite clockOff;
    bool playerPresent;
    [SerializeField] GameObject tempNPC;
    ClockMenu clockMenu;

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
            tempNPC.transform.localScale = new Vector3(1, 1, 1);
            if (playerPresent)
            {
                clockMenu.pause();
            }
        }
        else if (clockSprite.sprite == clockOn)
        {
            clockSprite.sprite = clockOff;
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

    //set colour to green
    void Awake()
    {

    }

    public void ManualHighlight()
    {
        //throw new System.NotImplementedException();
        Debug.Log("Clock Highlight is not implemented.");
    }

}
