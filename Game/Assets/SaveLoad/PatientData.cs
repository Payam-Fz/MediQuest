using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientData
{
    public int currentDialogueLevel;
    public int currentLineNumber;
    public string lastPersonTalked;
    public bool isTalking;
    public bool isComplete;
    public bool diagnosisComplete;
    public Dictionary<MedicalTest, bool> _testOrders;

    public PatientData(DialogueProgress dialPro, DiagnosisProgress diagPro)
    {
        this.currentDialogueLevel = dialPro.currentDialogueLevel;
        this.currentLineNumber = dialPro.currentLineNumber;
        this.lastPersonTalked = dialPro.lastPersonTalked;
        this.isTalking = dialPro.isTalking;
        this.isComplete = dialPro.isComplete;
        this.diagnosisComplete = diagPro.diagnosisComplete;
        this._testOrders = diagPro._testOrders;
    }
}
