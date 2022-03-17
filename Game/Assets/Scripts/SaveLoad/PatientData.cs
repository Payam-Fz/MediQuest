using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/* Stores the attributes/data of the patient
 * Author:  Min @ 2022-03-05
 */

[System.Serializable]
public class PatientData
{
    private string name;

    private int currentDialogueLevel;
    private int currentLineNumber;
    private string lastPersonTalked;
    private bool isTalking;
    private bool isComplete;

    private bool diagnosisComplete;
    private Diagnosis chosenDiagnosis;
    private string dateAndTime;
    private List<TestOrderPair> testOrders;

    public PatientData(string name, DialogueProgress dialPro, DiagnosisProgress diagPro)
    {
        this.name = name;
        this.currentDialogueLevel = dialPro.currentDialogueLevel;
        this.currentLineNumber = dialPro.currentLineNumber;
        this.lastPersonTalked = dialPro.lastPersonTalked;
        this.isTalking = dialPro.isTalking;
        this.isComplete = dialPro.isComplete;

        this.diagnosisComplete = diagPro.diagnosisComplete;
        this.chosenDiagnosis = diagPro.chosenDiagnosis;
        this.dateAndTime = diagPro.dateAndTime;
        this.testOrders = new List<TestOrderPair> ();
        foreach(var item in diagPro._testOrders)
        {
            this.testOrders.Add(new TestOrderPair(item.Key, item.Value));
        }
    }

    // Puts the content of this class to the corresponding assets
    public void LoadToObject()
    {
        GameObject patient = GameObject.Find(name);
        if (patient.tag != "Patient")
        {
            Debug.LogError("Patient object with name = " + name + " not found. ");
            return;
        }
        DialogueProgress dialProg = ScriptableObject.CreateInstance<DialogueProgress>();
        DiagnosisProgress diagProg = ScriptableObject.CreateInstance<DiagnosisProgress>();

        dialProg.currentDialogueLevel = this.currentDialogueLevel;
        dialProg.currentLineNumber = this.currentLineNumber;
        dialProg.lastPersonTalked = this.lastPersonTalked;
        dialProg.isTalking = this.isTalking;
        dialProg.isComplete = this.isComplete;

        diagProg.diagnosisComplete = this.diagnosisComplete;
        diagProg.chosenDiagnosis = this.chosenDiagnosis;
        diagProg.dateAndTime = this.dateAndTime;
        diagProg.testOrders = this.testOrders.ToArray();
        diagProg.populateDictionary();

        patient.GetComponent<DataContainer>().diagnosisProgress = diagProg;
        patient.GetComponent<DataContainer>().dialogueProgress = dialProg;
    }

}
