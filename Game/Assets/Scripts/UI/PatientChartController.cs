using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatientChartController : MonoBehaviour
{
    [SerializeField] GameObject chart_Canvas;
    private CharacterInfo patientBio;
    private CharacterInfo doctorBio;
    private DiagnosisProgress patientDiagnosisProgress;
    private MedicalInfo patientMedicalInfo;
    private GameObject currentPatient;

    public void AssignPatient(string objectName)
    {
        //chart_Canvas = GameObject.FindGameObjectWithTag("PatientChartCanvas");
        GameObject patient = GameObject.Find(objectName);
        if (patient.tag != "Patient")
        {
            Debug.LogError("Patient object with name = " + name + " not found. ");
            return;
        }
        currentPatient = patient;
        GameObject doctor = GameObject.FindGameObjectWithTag("Player");
        doctorBio = doctor.GetComponent<DataContainer>().characterInfo;
        patientBio = currentPatient.GetComponent<DataContainer>().characterInfo;
        patientDiagnosisProgress = currentPatient.GetComponent<DataContainer>().diagnosisProgress;
        patientMedicalInfo = currentPatient.GetComponent<DataContainer>().medicalInfo;
        FillChartFields();
    }

    // Payam F : Set up the remaining fields
    public void FillChartFields()
    {
        Sprite patient_image = Resources.Load<Sprite>(currentPatient.name);
        string dateTime = patientDiagnosisProgress.dateAndTime;
        string physician = doctorBio.Name;
        string name = patientBio.Name;
        string age = patientBio.Age.ToString();
        string sex = patientBio.Gender.ToString();
        Dictionary<MedicalTest, string> tests = getPatientTests();
        string complaint = patientMedicalInfo.chiefComplaint;
        string illness = patientMedicalInfo.presentIllness;
        string history = patientMedicalInfo.history;
        string dx = "";
        string plan = "";
        if (patientDiagnosisProgress.chosenDiagnosis != Diagnosis.Not_Diagnosed_Yet)
        {
            DiagnosesAndPlans reference = Resources.Load<DiagnosesAndPlans>("Functionality");
            DiagnosisNamePlanPair value;
            if (reference._diseaseInfo.TryGetValue(patientDiagnosisProgress.chosenDiagnosis, out value))
            {
                dx = value.nameOfDiagnosis;
                plan = value.plan;
            }
        }
        

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

    public void OrderTest(int testId)
    {
        MedicalTest medicalTest = (MedicalTest) testId;
        // Go through patientDiagnosisProgress._testOrders and set the value of the corresponding MedicalTest to true
        // then call the FillChartFields to refresh the patientchart content
        if (patientDiagnosisProgress._testOrders.ContainsKey(medicalTest))
        {
            patientDiagnosisProgress._testOrders[medicalTest] = true;
        }
        FillChartFields();
    }

    public void SetDiagnosis(Diagnosis selectedDiagnosis)
    {
        patientDiagnosisProgress.chosenDiagnosis = selectedDiagnosis;
        FillChartFields();
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
