using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Handles the interactions of Player with a Patient
 * Author:  Payam F @ 2021-11-06
 */
public class PatientInteractManager : NPCInteractManager
{
    [SerializeField] GameObject patientChart;
    public bool startDiagnosis = false;

    protected override void Start()
    {
        base.Start();
    }
    public override void Interact()
    {
        if (!isInteracting)
        {
            if (startDiagnosis)
            {
                isInteracting = true;
                patientChart.SetActive(true);
                patientChart.GetComponent<PatientChartController>().AssignPatient(gameObject.name);
            }
            else
            {
                base.Interact();
            }
        }
        
    }
}
