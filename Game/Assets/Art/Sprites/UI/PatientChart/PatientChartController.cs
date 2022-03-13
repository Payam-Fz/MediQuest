using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatientChartController : MonoBehaviour
{
    public Behaviour Chart_Canvas;
    [SerializeField] CharacterInfo patientBackground;
    [SerializeField] CharacterInfo doctorBackground;
    [SerializeField] DiagnosisProgress patientProgress;
    [SerializeField] MedicalInfo patientMedicalInfo;

    // Start is called before the first frame update
    void Start()
    {
        FillPatientBackground();
    }

    private void Update()
    {

    }

    void FillPatientBackground()
    {
        //string dateTime
        string physician = doctorBackground.Name;
        string name = patientBackground.Name;
        string age = patientBackground.age.ToString();
        string sex = patientBackground.gender.ToString();
        //string complaint;
        //string illness;
        //string history;
        //string test;
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
    }

    void Activate()
    {
        Debug.Log("Patient Chart has been activated");
        Chart_Canvas.GetComponent<Canvas>().gameObject.SetActive(true);
    }

    void Deactivate()
    {
        Debug.Log("Patient Chart has been deactivated");
        Chart_Canvas.GetComponent<Canvas>().gameObject.SetActive(true);
    }
}
