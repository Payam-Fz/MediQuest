using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;
using UnityEngine.EventSystems;

public class JournalController : MonoBehaviour
{
    [SerializeField] Animator journalAnimator;
    [SerializeField] GameObject systemPicker;
    [SerializeField] GameObject patientChart;
    //[SerializeField] string selectedButton;
    //[SerializeField] DialogueManager patientDialogueManager;


    Animator systemPickerAnimator;
    Animator patientChartAnimator;
    public static List<JournalButton> journalButtons = new List<JournalButton>();
    //private int currentPage = 0;
    //private int targetPage;
    private bool systemPickerUsed = false;
    private BodySystem pickedSystem;
    private JournalButton clickedButton;

    // Start is called before the first frame update
    void Start()
    {
        journalButtons.AddRange(Resources.FindObjectsOfTypeAll(typeof(JournalButton)) as JournalButton[]);
        Debug.Log("No. of Journal Buttons: " + journalButtons.Count);
        systemPickerAnimator = systemPicker.GetComponent<Animator>();
        patientChartAnimator = patientChart.GetComponent<Animator>();
        //patientDialogueManager = GameObject.FindGameObjectWithTag("Martha").GetComponent<DialogueManager>();
        StartCoroutine(OpenJournalDelay());
    }


    public void NavigateJournal()
    {
        clickedButton = EventSystem.current.currentSelectedGameObject.GetComponent<JournalButton>();
        if (!clickedButton.isSystemPicker && !clickedButton.isFinalDiagnosis)
        {
            if (clickedButton.isBackToSystemPicker)
            {
                systemPickerUsed = false;
                systemPicker.SetActive(false);
            }
            StartCoroutine(PageFlip());
        }
        else if (clickedButton.isSystemPicker)
        {
            //systemPickerUsed = true;
            StartCoroutine(SystemPicker());
        } else if (clickedButton.isFinalDiagnosis)
        {
            //Debug.Log("Final Diagnosis is checked");
            //patientDialogueManager.diagnosisDialogue.dialogueText = DiagnosisText();
            
            patientChart.GetComponent<PatientChartController>().SetDiagnosis(FinalizedDiagnosis());
            StartCoroutine(CloseJournal());
        }

        //selectedButton = clickedButton.buttonName;



    }

    private Diagnosis FinalizedDiagnosis()
    {
        int finalDiagnosisValue = (int) clickedButton.finalDiagnosis;
        if (systemPickerUsed)
        {
            finalDiagnosisValue += (int) pickedSystem;
        }

        return (Diagnosis)finalDiagnosisValue;
    }

    // To be called by system picker
    public void SelectBodySystem (BodySystem system)
    {
        systemPickerUsed = true;
        this.pickedSystem = system;
        StartCoroutine(PageFlip());
    }


    public void SystemPickerJournal()
    {
        StartCoroutine(DiagnoseSystem());
    }

    //string DiagnosisText()
    //{
    //    if (EventSystem.current.currentSelectedGameObject.GetComponent<JournalButton>().isSystem)
    //    {
    //        return ("(P): It looks like the problem is with your " + selectedButton + " system.");
    //    }
    //    else
    //    {
    //        return ("(P): It looks like you have a " + selectedButton + ".");
    //    }
    //}

    IEnumerator OpenJournalDelay()
    {
        yield return new WaitForSeconds(1f);
        foreach(var button in journalButtons)
        {
            if(button.currentPage == 0)
            {
                button.gameObject.SetActive(true);
            }
        }
    }

    IEnumerator CloseJournal()
    {
        journalAnimator.ResetTrigger("JournalExit");

        //currentPage = clickedButton.currentPage;

        foreach (var button in journalButtons)
        {
            if (button.currentPage == clickedButton.currentPage)
            {
                button.gameObject.SetActive(false);
            }
        }

        yield return new WaitForSeconds(0.2f);
        journalAnimator.SetTrigger("JournalExit");
        Debug.Log("Journal Closed");

    }


    IEnumerator PageFlip()
    {
        journalAnimator.ResetTrigger("PageFlip");
        journalAnimator.ResetTrigger("BackPageFlip");

        //currentPage = clickedButton.currentPage;
        //targetPage = clickedButton.targetPage;

        foreach (var button in journalButtons)
        {
            if (button.currentPage == clickedButton.currentPage)
            {
                button.gameObject.SetActive(false);
            }
        }

        if(clickedButton.targetPage > clickedButton.currentPage)
        {
            journalAnimator.SetTrigger("PageFlip");
        }
        else
        {
            journalAnimator.SetTrigger("BackPageFlip");
        }

        yield return new WaitForSeconds(0.5f);

        foreach (var button in journalButtons)
        {
            Debug.Log(button.currentPage);
            if (button.currentPage == clickedButton.targetPage)
            {
                Debug.Log(button.name);
                button.gameObject.SetActive(true);
                if (button.isFinalDiagnosis)
                {
                    button.SetDiagnosisAndPlan(FinalizedDiagnosis());    //pass the FINALIZED diagnosis to this function
                }
            }
        }

        //currentPage = targetPage;
    }


    IEnumerator SystemPicker()
    {
        //journalAnimator.ResetTrigger("JournalExit");
        
        if (!systemPickerUsed)
        {

            foreach (var button in journalButtons)
            {
                if (button.currentPage == clickedButton.currentPage)
                {
                    button.gameObject.SetActive(false);
                }
            }

            //journalAnimator.SetTrigger("JournalExit");
            yield return new WaitForSeconds(0.5f);


            systemPicker.SetActive(false);
            //patientChart.SetActive(false);
            systemPickerAnimator.SetBool("pickerUsed", false);
            //patientChartAnimator.SetBool("chartUsed", false);
            systemPicker.SetActive(true);
            //patientChart.SetActive(true);
        }

        //systemPickerUsed = true;
    }

    IEnumerator DiagnoseSystem()
    {
        //if (systemPickerUsed)
        //{
        //    Debug.Log("system picker used nutty");
        //    systemPickerAnimator.SetBool("pickerUsed", true);
        //    patientChartAnimator.SetBool("chartUsed", true);
        //    yield return new WaitForSeconds(0.35f);
        //    journalAnimator.SetTrigger("JournalEnter");

        //    string currentSystem = systemPicker.GetComponent<SystemPicker>().selectedSystem;

        //    yield return new WaitForSeconds(1.5f);
        //    foreach (var button in journalButtons)
        //    {
        //        if (button.buttonName == currentSystem || button.buttonName == selectedButton && button.currentPage > currentPage)
        //        {
        //            button.gameObject.SetActive(true);
        //        }
        //    }

        //    systemPickerUsed = false;
        //}
        yield return new WaitForSeconds(0.35f);
    }

}
