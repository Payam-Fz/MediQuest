using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/* Stores the attributes/data of the patient
 * Author:  Min @ 2022-03-05
 */

[System.Serializable]
public class StaffData
{
    public string name;
    public int currentDialogueLevel;
    public int currentLineNumber;
    public string lastPersonTalked;
    public bool isTalking;
    public bool isComplete;

    public StaffData(string name, DialogueProgress dialPro)
    {
        this.name = name;
        this.currentDialogueLevel = dialPro.currentDialogueLevel;
        this.currentLineNumber = dialPro.currentLineNumber;
        this.lastPersonTalked = dialPro.lastPersonTalked;
        this.isTalking = dialPro.isTalking;
        this.isComplete = dialPro.isComplete;
    }

    public void LoadToObject()
    {
        //GameObject staff = GameObject.Find(name);
        //if (staff.tag != "Staff")
        //{
        //    Debug.LogError("Staff object with name = " + name + " not found. ");
        //    return;
        //}
        //DialogueProgress dialProg = ScriptableObject.CreateInstance<DialogueProgress>();

        try
        {
            DialogueProgress dialProg = Resources.LoadAll<DialogueProgress>("Data/Staff/" + name)[0];
            dialProg.currentDialogueLevel = this.currentDialogueLevel;
            dialProg.currentLineNumber = this.currentLineNumber;
            dialProg.lastPersonTalked = this.lastPersonTalked;
            dialProg.isTalking = this.isTalking;
            dialProg.isComplete = this.isComplete;
        } catch (IndexOutOfRangeException ex)
        {
            Debug.LogError("Cannot load " + name + " data from resources.");
        } catch (NullReferenceException ex)
        {
            Debug.LogError("Cannot load " + name + " data from resources.");
        }
        
        //staff.GetComponent<DataContainer>().dialogueProgress = dialProg;
    }
}
