using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI textComponent;
    [SerializeField] Dialogue startingDialogue;
    [SerializeField] public Dialogue postDiagnosisDialogue;
    [SerializeField] Button nextButton;
    [SerializeField] Button startDiagnosisButton;
    Dialogue dialogue;
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
            startDiagnosisButton.gameObject.SetActive(true);
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

        gameObject.SetActive(false);
        gameObject.SetActive(true);
        dialogue = postDiagnosisDialogue;
        animator.SetBool("IsOpen", true);

        StopAllCoroutines();

        StartCoroutine(TypeStartSentence());

        nextButton.gameObject.SetActive(true);
    }

    public void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        GetComponent<Patient>().isTalking = false;
    }

    public void StartDiagnosis()
    {
        animator.SetBool("IsOpen", false);
        dialogue = postDiagnosisDialogue;
        journal.SetActive(true);
    }

    IEnumerator TypeStartSentence()
    {
        textComponent.text = "";

        foreach (char letter in startingDialogue.GetDialogueStory().ToCharArray())
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
