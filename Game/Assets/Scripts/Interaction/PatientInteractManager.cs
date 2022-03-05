using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Handles the interactions of Player with a Patient
 * Author:  Payam F @ 2021-11-06
 */
public class PatientInteractManager : NPCInteractManager
{
    public bool startedDiagnosis = false;

    public override void Interact()
    {
        if (!isTalking && !startedDiagnosis)
        {
            dialogueManager.StartDialogue();
            isTalking = true;
        }
        else
        {
            dialogueManager.ManageDialogue();
        }
    }

}
