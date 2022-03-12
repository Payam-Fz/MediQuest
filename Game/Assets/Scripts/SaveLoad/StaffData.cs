using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Stores the attributes/data of the patient
 * Author:  Min @ 2022-03-05
 */

[System.Serializable]
public class StaffData
{
    public int currentDialogueLevel;
    public int currentLineNumber;
    public string lastPersonTalked;
    public bool isTalking;
    public bool isComplete;

    public StaffData(DialogueProgress dialPro)
    {
        this.currentDialogueLevel = dialPro.currentDialogueLevel;
        this.currentLineNumber = dialPro.currentLineNumber;
        this.lastPersonTalked = dialPro.lastPersonTalked;
        this.isTalking = dialPro.isTalking;
        this.isComplete = dialPro.isComplete;
    }

    public void LoadToObject()
    {
        
    }
}
