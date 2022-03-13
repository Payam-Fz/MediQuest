using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatientChartController : MonoBehaviour
{
    public Behaviour chart_Canvas;
    [SerializeField] CharacterInfo patientBackground;
    [SerializeField] CharacterInfo doctorBackground;
    [SerializeField] DiagnosisProgress patientProgress;
    [SerializeField] MedicalInfo patientMedicalInfo;

    // Start is called before the first frame update
    void Start()
    {
        FillPatientBackground();
    }
    void FillPatientBackground()
    {
        //string dateTime
        string physician = doctorBackground.Name;
        string name = patientBackground.Name;
        string age = patientBackground.age.ToString();
        string sex = patientBackground.gender.ToString();
        Dictionary<MedicalTest, string> tests = getPatientTests();
        //string complaint;
        //string illness;
        //string history;
        //string dx;
        //string plan;

        Transform physician_name = transform.Find("Physician");
        physician_name.GetComponent<Text>().text = physician;

        Transform patient_name = transform.Find("Name");
        patient_name.GetComponent<Text>().text = name;

        Transform patient_age = transform.Find("Age");
        patient_age.GetComponent<Text>().text = age;

        Transform patient_sex = transform.Find("Sex");
        patient_sex.GetComponent<Text>().text = sex;

        Transform patient_tests = transform.Find("Test");
        foreach (var test in tests)
        {
            patient_tests.GetComponent<Text>().text = Enum.GetName(typeof(MedicalTest), test.Key) + ": " + test.Value + "\n";
        }

    }

    Dictionary<MedicalTest, string> getPatientTests()
    {
        Dictionary<MedicalTest, string> final_results = new Dictionary<MedicalTest, string>();
        foreach (var item in patientProgress.testOrders)
        {
            if (item.isOrdered == true)
            {
                string result = patientMedicalInfo._testResults[item.testName];
                final_results.Add(item.testName, result);
            }
        }
        return final_results;
    }

    void Activate()
    {
        Debug.Log("Patient Chart has been activated");
        chart_Canvas.GetComponent<Canvas>().gameObject.SetActive(true);
    }

    void Deactivate()
    {
        Debug.Log("Patient Chart has been deactivated");
        chart_Canvas.GetComponent<Canvas>().gameObject.SetActive(true);
    }
}
