using System.Collections.Generic;
using UnityEngine;


/*
 * A pair for <MedicalTest, Result>
 */
[System.Serializable]
public struct TestResultPair
{
    public MedicalTest testName;
    public string result;
}


/*
 * Stores the data specific to a patient character
 * Author:     Payam F & Nokia T @ 2021-11-27
 */
[CreateAssetMenu(fileName = "PatientMedicalInfo", menuName = "CodeBlue/PatientMedicalInfo")]
public class PatientMedicalInfo : ScriptableObject
{
    [Range(1, 5)] [SerializeField] int difficulty;
    [SerializeField] int correctDiagnosisID;
    [SerializeField] int[] nearCorrectDiagnosisID;
    [SerializeField] int[] preferredBedNumbers;
    [SerializeField] MedicalTest[] necessaryTests;
    [SerializeField] TestResultPair[] testResults = new TestResultPair[21];
    public Dictionary<MedicalTest, string> _testResults;

    void Awake()
    {
        _testResults = new Dictionary<MedicalTest, string>();
        foreach(TestResultPair pair in testResults)
        {
            _testResults.Add(pair.testName, pair.result);
        }
    }

    public int[] getBedNumber()
    {
        return preferredBedNumbers;
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
    public bool checkNearCorrect(int diagnosisID)
    {
        for (int i = 0; i < nearCorrectDiagnosisID.Length; i++)
        {
            if (diagnosisID == nearCorrectDiagnosisID[i])
            {
                return true;
            }
        }

        return false;
    }
}
