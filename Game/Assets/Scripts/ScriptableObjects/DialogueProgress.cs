using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Stores the data for current state of dialogue with an NPC
 * Author:     Payam F @ 2022-01-22
 */
[CreateAssetMenu(fileName = "DialogueProgress_name", menuName = "CodeBlue/Dialogue Progress")]
public class DialogueProgress : ScriptableObject
{
    [SerializeField] int currentDialogueLevel;
    [SerializeField] int currentLineNumber;
    [SerializeField] string lastPersonTalked;
    [SerializeField] bool isTalking;
    [SerializeField] bool isComplete;
}
