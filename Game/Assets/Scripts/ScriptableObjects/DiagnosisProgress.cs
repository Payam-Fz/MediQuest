using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
  * A pair for <MedicalTest, bool>
  */
[System.Serializable]
public struct TestOrderPair
{
    public MedicalTest testName;
    public bool isOrdered;

    public TestOrderPair (MedicalTest testName, bool isOrdered)
    {
        this.testName = testName;
        this.isOrdered = isOrdered;
    }
}

/*
 * Stores the data for current state of a patient diagnosis
 * Author:     Payam F @ 2022-01-22
 */
[CreateAssetMenu(fileName = "DiagnosisProgress_name", menuName = "CodeBlue/Diagnosis Progress")]
public class DiagnosisProgress : ScriptableObject
{
    [SerializeField] public string dateAndTime;
    [SerializeField] public bool diagnosisComplete = false;
    [SerializeField] public Diagnosis chosenDiagnosis = Diagnosis.Not_Diagnosed_Yet;

    [SerializeField] public TestOrderPair[] testOrders = new TestOrderPair[26]; // Only for display in editor and loading data
    public Dictionary<MedicalTest, bool> _testOrders;

    void OnEnable()
    {
        populateDictionary();
    }

    public void populateDictionary()
    {
        _testOrders = new Dictionary<MedicalTest, bool>();
        foreach (TestOrderPair pair in testOrders)
        {
            _testOrders.Add(pair.testName, pair.isOrdered);
        }
        Debug.Log("_testOrders: ");
        Debug.Log(_testOrders);
    }
}
