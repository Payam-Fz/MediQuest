using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Stores the data for current state of a patient diagnosis
 * Author:     Payam F @ 2022-01-22
 */
[CreateAssetMenu(fileName = "DiagnosisProgress_name", menuName = "CodeBlue/Diagnosis Progress")]
public class DiagnosisProgress : ScriptableObject
{
    /*
     * A pair for <MedicalTest, bool>
     */
    [System.Serializable]
    private struct TestOrderPair
    {
        public MedicalTest testName;
        public bool isOrdered;
    }

    [SerializeField] bool diagnosisComplete;
    [SerializeField] TestOrderPair[] testOrders = new TestOrderPair[21];
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
