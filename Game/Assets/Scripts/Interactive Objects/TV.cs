using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV : MonoBehaviour, IInteractive
{
    SpriteRenderer tvSprite;
    [SerializeField] Sprite tvOn;
    [SerializeField] Sprite tvOff;

    [SerializeField] GameObject tempNPC;
    AudioSource tvSound;
    bool playerPresent;

    
    void Start()
    {
        tvSprite = GetComponent<SpriteRenderer>();
        tvSound = GetComponent<AudioSource>();
    }
    
    public void Interact()
    {
        if(tvSprite.sprite == tvOff)
        {
            tvSprite.sprite = tvOn;
            tempNPC.transform.localScale = new Vector3(1, 1, 1);
            if (playerPresent)
            {
                tvSound.Play();
            }
        } 
        else if(tvSprite.sprite == tvOn)
        {
            tvSprite.sprite = tvOff;
            tvSound.Stop();
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Player is at the TV");
        
        if (collision.tag == "PlayerTag")
        {
            playerPresent = true;
            if(tvSprite.sprite == tvOn)
            {
                tvSound.Play();
            }
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "PlayerTag")
        {
            playerPresent = false;
            tvSound.Stop();
        }
    }

    public void ManualHighlight()
    {
        //throw new System.NotImplementedException();
        Debug.Log("TV Highlight is not implemented.");
    }
}
