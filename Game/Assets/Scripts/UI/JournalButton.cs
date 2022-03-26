using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class JournalButton : MonoBehaviour
{
    Button journalButton;
    [SerializeField] public string buttonName;
    [SerializeField] public int currentPage;
    [SerializeField] public int targetPage;
    //[SerializeField] public bool isSystem;
    [SerializeField] public bool isSystemPicker;
    [SerializeField] public bool isBackToSystemPicker;
    [SerializeField] public bool isFinalDiagnosis;
    [SerializeField] public Diagnosis finalDiagnosis;
    Animator JournalAnimator;
    
    // Start is called before the first frame update
    void Start()
    {
        /*journalButton = gameObject.GetComponent<Button>();
        if(transform.parent.name == "Illnesses")
        {
            journalBranch = "Illness";
        }
        else
        {
            journalBranch = "Injury";
        }*/

        JournalAnimator = transform.parent.parent.GetComponent<Animator>();
        //JournalController.journalButtons.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDiagnosisAndPlan(Diagnosis finalDiagnosis)
    {
        if (isFinalDiagnosis)
        {
            DiagnosisNamePlanPair pair;
            Resources.Load<DiagnosesAndPlans>("Functionality/DiagnosesAndPlans")._diseaseInfo.TryGetValue(finalDiagnosis, out pair);
            transform.Find("dx").GetComponent<TextMeshProUGUI>().text = pair.nameOfDiagnosis;
            transform.Find("plan").GetComponent<TextMeshProUGUI>().text = pair.plan;
        }
    }
}
