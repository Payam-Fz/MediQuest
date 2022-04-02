using System.Collections.Generic;
using UnityEngine;



/*
 * Stores the data specific to a patient character
 * Author:     Payam F & Nokia T @ 2021-11-27
 */
[CreateAssetMenu(fileName = "MedicalInfo_name", menuName = "CodeBlue/Medical Info")]
public class MedicalInfo : ScriptableObject
{
    /*
     * A pair for <MedicalTest, Result>
     */
    [System.Serializable]
    private struct TestResultPair
    {
        public MedicalTest testName;
        public string result;
    }


    [Range(1, 5)] [SerializeField] int difficulty;
    [SerializeField] public Diagnosis correctDiagnosis;
    [SerializeField] public Diagnosis[] nearCorrectDiagnosis;
    [SerializeField] public int[] preferredBedNumbers;
    [SerializeField] public MedicalTest[] necessaryTests;
    [SerializeField] public string chiefComplaint;
    [SerializeField] public string presentIllness;
    [SerializeField] public string history;
    [SerializeField] TestResultPair[] testResults = new TestResultPair[26]; // Only for display in editor
    public Dictionary<MedicalTest, string> _testResults;

    void Awake()
    {
        _testResults = new Dictionary<MedicalTest, string>();
        foreach(TestResultPair pair in testResults)
        {
            _testResults.Add(pair.testName, pair.result);
        }
    }


    /*
     * Check if the diagnosis id input by the user is in the set of near correct diagnosis
     */
    public bool checkNearCorrect(Diagnosis diagnosis)
    {
        for (int i = 0; i < nearCorrectDiagnosis.Length; i++)
        {
            if (diagnosis == nearCorrectDiagnosis[i])
            {
                return true;
            }
        }

        return false;
    }
}
