using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteractManager : MonoBehaviour, IInteractable
{
    SpriteRenderer doorSprite;
    [SerializeField] Sprite doorClosed;
    [SerializeField] Sprite doorClosedHL;
    [SerializeField] Sprite doorOpen;
    [SerializeField] Sprite doorOpenHL;

    private GameObject player;
    [SerializeField] Transform doorEntrance;
    [SerializeField] Transform doorExit;
    bool playerInRoom = false;

    AudioSource doorOpenSound;

    
    void Start()
    {
        doorSprite = GetComponent<SpriteRenderer>();
        doorOpenSound = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Interact()
    {
        if (playerInRoom)
        {
            player.GetComponent<Rigidbody2D>().transform.position = doorEntrance.position;
            StartCoroutine(DoorDelay());
            playerInRoom = false;
            doorOpenSound.Play();
        } 
        else
        {
            player.gameObject.GetComponent<Rigidbody2D>().transform.position = doorExit.position;
            StartCoroutine(DoorDelay());
            playerInRoom = true;
            doorOpenSound.Play();
        }
    }

    public void ManualHighlight()
    {
        if(doorSprite.sprite == doorClosed)
        {
            doorSprite.sprite = doorClosedHL;
        }
        else if(doorSprite.sprite == doorClosedHL)
        {
            doorSprite.sprite = doorClosed;
        }
        else if(doorSprite.sprite == doorOpen)
        {
            doorSprite.sprite = doorOpenHL;
        }
        else if(doorSprite.sprite == doorOpenHL)
        {
            doorSprite.sprite = doorOpen;
        }
    }

    IEnumerator DoorDelay()
    {
        yield return new WaitForSeconds(1f);
    }

}
