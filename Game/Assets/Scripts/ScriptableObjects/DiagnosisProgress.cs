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
}

/*
 * Stores the data for current state of a patient diagnosis
 * Author:     Payam F @ 2022-01-22
 */
[CreateAssetMenu(fileName = "DiagnosisProgress_name", menuName = "CodeBlue/Diagnosis Progress")]
public class DiagnosisProgress : ScriptableObject
{
    [SerializeField] public bool diagnosisComplete;
    [SerializeField] public TestOrderPair[] testOrders = new TestOrderPair[26];
    public Dictionary<MedicalTest, bool> _testOrders;

    void Awake()
    {
        _testOrders = new Dictionary<MedicalTest, bool>();
        foreach (TestOrderPair pair in testOrders)
        {
            _testOrders.Add(pair.testName, pair.isOrdered);
        }
    }
}
