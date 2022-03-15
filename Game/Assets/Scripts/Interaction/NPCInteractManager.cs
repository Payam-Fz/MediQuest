﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Handles interaction of Player with an NPC
 * Author:  Apoorv T @ 2020-10-10
 * Updated: Payam F @ 2021-11-06
 */
public class NPCInteractManager : MonoBehaviour, IInteractable
{
    protected DialogueManager dialogueManager;
    public bool isTalking = false;
    

    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = GetComponent<DialogueManager>();
    }

    public virtual void Interact()
    {
        if (!isTalking)
        {
            dialogueManager.StartDialogue();
            isTalking = true;
        }
        else
        {
            dialogueManager.ManageDialogue();
        }
    }


    public void ManualHighlight()
    {
        //throw new System.NotImplementedException();
        Debug.Log("Manual highlight for patient not implemented");
    }
}