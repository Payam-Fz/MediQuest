using System.Collections.Generic;
using UnityEngine;


/*
 * The name and plan for each of the disease
*/
[System.Serializable]
public struct DiagnosisNamePlanPair
{
    public Diagnosis diagnosis;
    public string nameOfDiagnosis;
    public string plan;    // In future, you can turn this into an array of string for more options of plan
}


/*
 * Data for all diseases
 */
[CreateAssetMenu(fileName = "DiagnosesAndPlans", menuName = "CodeBlue/Diagnoses and Plans")]
public class DiagnosesAndPlans : ScriptableObject
{

    [SerializeField] DiagnosisNamePlanPair[] diseaseInfo = new DiagnosisNamePlanPair[61];
    public Dictionary<Diagnosis, DiagnosisNamePlanPair> _diseaseInfo;

    // Start is called before the first frame update
    void Awake()
    {
        _diseaseInfo = new Dictionary< Diagnosis, DiagnosisNamePlanPair> ();
        foreach (DiagnosisNamePlanPair pair in diseaseInfo)
        {
            _diseaseInfo.Add(pair.diagnosis, pair);
        }
    }
}
