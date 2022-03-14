using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVInteractManager : MonoBehaviour, IInteractable
{
    SpriteRenderer tvSprite;
    [SerializeField] Sprite tvOn;
    [SerializeField] Sprite tvOff;

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
        if (collision.tag == "Player")
        {
            Debug.Log("Player is at the TV");
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
