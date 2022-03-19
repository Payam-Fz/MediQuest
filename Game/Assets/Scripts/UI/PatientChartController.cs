using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatientChartController : MonoBehaviour
{
    public GameObject chart_Canvas;
    [SerializeField] CharacterInfo patientBio;
    [SerializeField] CharacterInfo doctorBio;
    [SerializeField] DiagnosisProgress patientDiagnosisProgress;
    [SerializeField] MedicalInfo patientMedicalInfo;

    public void AssignAndFillPlayerDetails(string objectName)
    {
        chart_Canvas = GameObject.FindGameObjectWithTag("PatientChartCanvas");
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
        FillPatientBackground(patient);
    }

    // Payam F : Set up the remaining fields
    public void FillPatientBackground(GameObject p)
    {
        Sprite patient_image = Resources.Load<Sprite>(p.name);
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

        Transform patient_img = chart_Canvas.transform.Find("PatientIMG");
        patient_img.GetComponent<UnityEngine.UI.Image>().sprite = patient_image;

        Transform physician_name = chart_Canvas.transform.Find("Physician");
        physician_name.GetComponent<UnityEngine.UI.Text>().text = physician;

        Transform patient_name = chart_Canvas.transform.Find("Name");
        patient_name.GetComponent<UnityEngine.UI.Text>().text = name;

        Transform patient_age = chart_Canvas.transform.Find("Age");
        patient_age.GetComponent<UnityEngine.UI.Text>().text = age;

        Transform patient_sex = chart_Canvas.transform.Find("Sex");
        patient_sex.GetComponent<UnityEngine.UI.Text>().text = sex;

        Transform patient_tests = chart_Canvas.transform.Find("Test");
        foreach (var test in tests)
        {
            patient_tests.GetComponent<UnityEngine.UI.Text>().text = Enum.GetName(typeof(MedicalTest), test.Key) + ": " + test.Value + "\n";
        }

        Transform patient_complaint = chart_Canvas.transform.Find("Complaint");
        patient_complaint.GetComponent<UnityEngine.UI.Text>().text = complaint;

        Transform patient_illness = chart_Canvas.transform.Find("Illness");
        patient_illness.GetComponent<UnityEngine.UI.Text>().text = illness;

        Transform patient_history = chart_Canvas.transform.Find("History");
        patient_history.GetComponent<UnityEngine.UI.Text>().text = history;

        Transform patient_dx = chart_Canvas.transform.Find("DX");
        patient_dx.GetComponent<UnityEngine.UI.Text>().text = dx;

        Transform patient_plan = chart_Canvas.transform.Find("Plan");
        patient_plan.GetComponent<UnityEngine.UI.Text>().text = plan;
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
