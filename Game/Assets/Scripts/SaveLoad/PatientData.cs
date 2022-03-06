using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Stores the attributes/data of the patient
 * Author:  Min @ 2022-03-05
 */

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

    public void SavePatientData()
    {
        SaveLoadSystem.SavePatientData();
    }

    public void LoadPatientData()
    {
        DialogueProgress dialogueProgress = ScriptableObject.CreateInstance<DialogueProgress>();
        DiagnosisProgresss diagnosisProgress = ScriptableObject.CreateInstance<DiagnosisProgress>();

        PatientData patientData = SaveLoadSystem.LoadPatientData;

        dialogueProgress.currentDialogueLevel = patientData.currentDialogueLevel;
        dialogueProgress.currentLineNumber = patientData.currentLineNumber;
        dialogueProgress.lastPersonTalked = patientData.lastPersonTalked;
        dialogueProgress.isTalking = patientData.isTalking;
        dialogueProgress.isComplete = patientData.isComplete;
        diagnosisProgress.diagnosisComplete = patientData.diagnosisComplete;

        foreach (KeyValuePair<TKey, TValue> pair in dictionary)
        {
            this.Add(pair.Key, pair.Value);
        }

        //AssetDatabase.CreateAsset(characterInfo, resource_path + "/Player/CharacterInfo_Player.asset");
        //AssetDatabase.SaveAssets();
        //AssetDatabase.Refresh();
        //EditorUtility.FocusProjectWindow();
        //Selection.activeObject = ;
    }

    // TODO: LoadPatientData(for each loop for dictionary), LoadStaffData from this
	// TODO: LoadPatientData, LoadStaffData from SaveLoadSystem (use for loop)
}
