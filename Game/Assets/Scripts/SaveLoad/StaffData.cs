using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
