using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatientChartController : MonoBehaviour
{
    public Behaviour chart_Canvas;
    [SerializeField] CharacterInfo patientBio;
    [SerializeField] CharacterInfo doctorBio;
    [SerializeField] DiagnosisProgress patientDiagnosisProgress;
    [SerializeField] MedicalInfo patientMedicalInfo;

    // Start is called before the first frame update

    public void AssignAndFillPlayerDetails(string objectName)
    {
        GameObject patient = GameObject.Find(objectName);
        if (patient.tag != "Patient")
        {
            Debug.LogError("Patient object with name = " + name + " not found. ");
            return;
        }
        GameObject doctor = GameObject.FindGameObjectWithTag("Player");
        patientBio = patient.GetComponent<DataContainer>().characterInfo;
        doctorBio = doctor.GetComponent<DataContainer>().characterInfo;
        patientDiagnosisProgress = patient.GetComponent<DataContainer>().diagnosisProgress;
        patientMedicalInfo = patient.GetComponent<DataContainer>().medicalInfo;
        FillPatientBackground();
    }

    // Payam F : Set up the remaining fields
    public void FillPatientBackground()
    {
        string dateTime = patientDiagnosisProgress.dateAndTime;
        string physician = doctorBio.Name;
        string name = patientBio.Name;
        string age = patientBio.age.ToString();
        string sex = patientBio.gender.ToString();
        Dictionary<MedicalTest, string> tests = getPatientTests();
        string complaint = patientMedicalInfo.chiefComplaint;
        string illness = patientMedicalInfo.presentIllness;
        string history = patientMedicalInfo.history;
        string dx = "";
        string plan = "";
        DiagnosesAndPlans reference = Resources.Load<DiagnosesAndPlans>("Functionality");
        DiagnosisNamePlanPair value;
        if (reference._diseaseInfo.TryGetValue(patientDiagnosisProgress.chosenDiagnosis, out value))
        {
            dx = value.nameOfDiagnosis;
            plan = value.plan;
        }

        // Yan, please use the remaining fields

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
        foreach (var item in patientDiagnosisProgress._testOrders)
        {
            if (item.Value == true)
            {
                string result = patientMedicalInfo._testResults[item.Key];
                final_results.Add(item.Key, result);
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
        chart_Canvas.GetComponent<Canvas>().gameObject.SetActive(false);
    }
}
