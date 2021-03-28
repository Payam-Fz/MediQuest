using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI textComponent;
    [SerializeField] Dialogue startingDialogue;
    [SerializeField] public Dialogue diagnosisDialogue;
    [SerializeField] Dialogue diagnosisDoneDialogue;
    [SerializeField] Button nextButton;
    [SerializeField] Button startDiagnosisButton;
    Dialogue dialogue;
    bool diagnosisDone = false;
    [SerializeField] Animator animator;
    [SerializeField] GameObject journal;

    // Start is called before the first frame update
    void Start()
    {

        dialogue = startingDialogue;
    }

    
    public void ManageDialogue()
    {
        
        
        var nextDialogue = dialogue.GetNextDialogue();
       
        dialogue = nextDialogue[0];
        StopAllCoroutines();
        StartCoroutine(TypeSentence());
        if (dialogue.GetNextDialogue().Length == 0)
        {
            nextButton.gameObject.SetActive(false);
            if(startDiagnosisButton != null && !diagnosisDone)
            {
                startDiagnosisButton.gameObject.SetActive(true);
            }

            
        }
        
    }
    public void StartDialogue()
    {
        //dialogue = startingDialogue;

        animator.SetBool("IsOpen", true);
        
        StopAllCoroutines();
        
        StartCoroutine(TypeStartSentence());
        
        nextButton.gameObject.SetActive(true);
    }

    public void StartDiagnosisDialogue()
    {
        diagnosisDone = true;
        startDiagnosisButton.gameObject.SetActive(false);
        dialogue = diagnosisDialogue;
        animator.SetBool("IsOpen", true);

        StopAllCoroutines();

        StartCoroutine(TypeStartSentence());

        nextButton.gameObject.SetActive(true);
    }

    public void TestDialogueBox()
    {
        animator.SetBool("IsOpen", true);
        Debug.Log("Dialogue Box is Open");
    }

    public void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        GetComponent<Patient>().isTalking = false;
        if (dialogue.GetNextDialogue().Length == 0 && diagnosisDone)
        {
            dialogue = diagnosisDoneDialogue;
        }
    }

    public void StartDiagnosis()
    {
        animator.SetBool("IsOpen", false);
        dialogue = diagnosisDialogue;
        journal.SetActive(true);
    }

    IEnumerator TypeStartSentence()
    {
        textComponent.text = "";

        foreach (char letter in dialogue.GetDialogueStory().ToCharArray())
        {
            textComponent.text += letter;
            yield return new WaitForSeconds(0.02f);

        }

    }
    IEnumerator TypeSentence()
    {
        textComponent.text = "";
        foreach(char letter in dialogue.GetDialogueStory().ToCharArray())
        {
            textComponent.text += letter;
            yield return new WaitForSeconds(0.02f); 
        }
    }
}
