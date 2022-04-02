using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Handles interaction of Player with an NPC
 * Author:  Apoorv T @ 2020-10-10
 * Updated: Payam F @ 2021-11-06
 */
public class NPCInteractManager : MonoBehaviour, IInteractable
{
    protected LevelDialogueManager dialogueManager;
    public bool isInteracting = false;
    

    // Start is called before the first frame update
    protected virtual void Start()
    {
        dialogueManager = GetComponent<LevelDialogueManager>();
    }

    public virtual void MakeInteractable ()
    {
        isInteracting = false;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerController>().enabled = true;
    }

    public virtual void Interact()
    {
        if (!isInteracting)
        {
            dialogueManager.OpenDialogue();
            isInteracting = true;
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<PlayerController>().enabled = false;
            player.transform.Find("Sprites").GetComponent<Animator>().SetInteger("Direction", 10);
        }
    }


    public void ManualHighlight()
    {
        //throw new System.NotImplementedException();
        Debug.Log("Manual highlight for patient not implemented");
    }
}
