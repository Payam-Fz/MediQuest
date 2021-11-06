using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PatientInfo", menuName = "CodeBlue/Character/PatientInfo", order = 1)]
/*
 * Stores the data specific to a patient character
 * Author:     Nokia T @ 2021-10-30
 */
public class PatientInfo : CharacterInfo
{
    [SerializeField] public int bedNumber;
    [SerializeField] public int correctDiagnosisID;
    [SerializeField] public int[] nearCorrectDiagnosisID;
    [Range(1, 5)] [SerializeField] public int difficulty;

    public int getBedNumber()
    {
        return bedNumber;
    }

    public int getCorrectDiag()
    {
        return correctDiagnosisID;
    }

    public int getDifficulty()
    {
        return difficulty;
    }

    /*
     * Check if the diagnosis id input by the user is in the set of near correct diagnosis
     */
    public bool checkNearCorrect(int diag)
    {
        for (int i = 0; i < nearCorrectDiagnosisID.Length; i++)
        {
            if (diag == nearCorrectDiagnosisID[i])
            {
                return true;
            }
        }

        return false;
    }
}
