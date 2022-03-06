using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientChartController : MonoBehaviour
{
    Canvas patientChart;
    [SerializeField] CharacterInfo patientBackground;
    [SerializeField] DiagnosisProgress patientProgress;
    [SerializeField] MedicalInfo patientMedicalInfo;

    // Start is called before the first frame update
    void Start()
    {
        patientChart = GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FillPatientBackground()
    {

    }

    void Activate()
    {
        Debug.Log("Patient Chart has been activated");
        patientChart.gameObject.SetActive(true);
    }

    void Deactivate()
    {
        Debug.Log("Patient Chart has been deactivated");
        patientChart.gameObject.SetActive(false);
    }
}
