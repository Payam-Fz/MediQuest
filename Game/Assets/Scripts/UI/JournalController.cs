using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;
using UnityEngine.EventSystems;
using UnityEditorInternal;

public class JournalController : MonoBehaviour
{
    [SerializeField] Animator journalAnimator;
    [SerializeField] GameObject systemPicker;
    [SerializeField] GameObject patientChart;
    Animator systemPickerAnimator;
    Animator patientChartAnimator;
    public static List<JournalButton> journalButtons = new List<JournalButton>();
    [SerializeField] string selectedButton;
    [SerializeField] string postDiagnosisDialogue;
    
    // Start is called before the first frame update
    void Start()
    {
        journalButtons.AddRange(Resources.FindObjectsOfTypeAll(typeof(JournalButton)) as JournalButton[]);
        Debug.Log("No. of Journal Buttons: " + journalButtons.Count);
        StartCoroutine(OpenJournalDelay());
        systemPickerAnimator = systemPicker.GetComponent<Animator>();
        patientChartAnimator = patientChart.GetComponent<Animator>();
        postDiagnosisDialogue = FindObjectOfType<DialogueManager>().postDiagnosisDialogue.dialogueText;
    }


    public void NavigateJournal()
    {

        if (!EventSystem.current.currentSelectedGameObject.GetComponent<JournalButton>().systemPicker && 
            !EventSystem.current.currentSelectedGameObject.GetComponent<JournalButton>().finalDiagnosis)
        {
            StartCoroutine(PageFlip());
        }
        else if (!EventSystem.current.currentSelectedGameObject.GetComponent<JournalButton>().finalDiagnosis)
        {
            StartCoroutine(SystemPicker());
        }

        if (EventSystem.current.currentSelectedGameObject.GetComponent<JournalButton>().finalDiagnosis)
        {
            Debug.Log("Final Diagnosis is checked");
            StartCoroutine(CloseJournal());
        }

        selectedButton = EventSystem.current.currentSelectedGameObject.GetComponent<JournalButton>().buttonName;
    }


    public void SystemPickerJournal()
    {
        StartCoroutine(DiagnoseSystem());
    }

    IEnumerator OpenJournalDelay()
    {
        yield return new WaitForSeconds(1f);
        foreach(var button in journalButtons)
        {
            if(button.buttonPage == 0)
            {
                button.gameObject.SetActive(true);
            }
        }
    }

    IEnumerator CloseJournal()
    {
        Debug.Log("Journal Closing");
        
        journalAnimator.ResetTrigger("JournalExit");

        currentPage = EventSystem.current.currentSelectedGameObject.GetComponent<JournalButton>().buttonPage;

        foreach (var button in journalButtons)
        {
            if (button.buttonPage == currentPage)
            {
                button.gameObject.SetActive(false);
            }
        }

        yield return new WaitForSeconds(0.2f);
        journalAnimator.SetTrigger("JournalExit");

        Debug.Log("Journal Closed");

    }

    int currentPage;
    int currentTargetPage;

    IEnumerator PageFlip()
    {
        journalAnimator.ResetTrigger("PageFlip");
        journalAnimator.ResetTrigger("BackPageFlip");

        currentPage = EventSystem.current.currentSelectedGameObject.GetComponent<JournalButton>().buttonPage;
        currentTargetPage = EventSystem.current.currentSelectedGameObject.GetComponent<JournalButton>().targetPage;
        Debug.Log(currentTargetPage);

        foreach (var button in journalButtons)
        {
            if (button.buttonPage == currentPage)
            {
                button.gameObject.SetActive(false);
            }
        }

        if(currentTargetPage > currentPage)
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
            Debug.Log(button.buttonPage);
            if (button.buttonPage == currentTargetPage)
            {
                Debug.Log(button.name);
                button.gameObject.SetActive(true);
            }
        }

        currentPage = currentTargetPage;
    }

    bool systemPickerUsed;

    IEnumerator SystemPicker()
    {
        journalAnimator.ResetTrigger("JournalExit");
        
        if (!systemPickerUsed)
        {

            foreach (var button in journalButtons)
            {
                if (button.buttonPage == currentPage)
                {
                    button.gameObject.SetActive(false);
                }
            }

            journalAnimator.SetTrigger("JournalExit");
            yield return new WaitForSeconds(0.5f);


            systemPicker.SetActive(false);
            patientChart.SetActive(false);
            systemPickerAnimator.SetBool("pickerUsed", false);
            patientChartAnimator.SetBool("chartUsed", false);
            systemPicker.SetActive(true);
            patientChart.SetActive(true);
        }

        systemPickerUsed = true;
    }

    IEnumerator DiagnoseSystem()
    {
        if (systemPickerUsed)
        {
            Debug.Log("system picker used nutty");
            systemPickerAnimator.SetBool("pickerUsed", true);
            patientChartAnimator.SetBool("chartUsed", true);
            yield return new WaitForSeconds(0.35f);
            journalAnimator.SetTrigger("JournalEnter");

            string currentSystem = systemPicker.GetComponent<SystemPicker>().selectedSystem;

            yield return new WaitForSeconds(1.5f);
            foreach (var button in journalButtons)
            {
                if (button.buttonName == currentSystem || button.buttonName == selectedButton && button.buttonPage > currentPage)
                {
                    button.gameObject.SetActive(true);
                }
            }

            systemPickerUsed = false;
        }
    }

}
