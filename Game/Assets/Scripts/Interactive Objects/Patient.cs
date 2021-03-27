using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patient : MonoBehaviour, IInteractive
{
    DialogueManager dialogueManager;
    public bool isTalking = false;
    public bool startedDiagnosis = false;

    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = GetComponent<DialogueManager>();
    }

    public void Interact()
    {
        if (!isTalking && !startedDiagnosis)
        {
            dialogueManager.StartDialogue();
            isTalking = true;
        }
        else
        {
            dialogueManager.ManageDialogue();
        }
    }


    public void ManualHighlight()
    {
        //throw new System.NotImplementedException();
        Debug.Log("Manual highlight for patient not implemented");
    }
}
