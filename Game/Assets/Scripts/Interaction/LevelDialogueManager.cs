using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


/*
 * Handles the dialogue of an NPC
 * Author:  Yan W @ 2022-01-22
 * Updated: Payam F @ 2022-01-29
 */
public class LevelDialogueManager : MonoBehaviour
{
    [SerializeField] string dataPath;
    [SerializeField] Animator animator;
    //[SerializeField] GameObject journal;
    [SerializeField] GameObject dialogueBoxPrefab;
    [SerializeField] GameObject endCanvas;
    
    private TextMeshProUGUI textComponent;
    private Button nextButton;
    private Button previousButton;
    private LevelDialogue dialogue;
    private DialogueProgress dialogueProgress;

    private int currentDialogueLevel;
    private int currentLineNumber;
    private string lastPersonTalked;
    private bool isTalking;
    private bool isComplete;

    private List<List<Tuple<string, string>>> TupleDialogue;
    List<string> levelText = new List<string>();


    // Start is called before the first frame update
    void Start()
    {
        dialogueBoxPrefab.SetActive(true);
        dialogue = Resources.Load<LevelDialogue>(dataPath);
        dialogueProgress = Resources.Load<DialogueProgress>(dataPath);
        textComponent = dialogueBoxPrefab.GetComponentInChildren<TextMeshProUGUI>();
        nextButton = dialogueBoxPrefab.transform.Find("Next Button").gameObject.GetComponent<Button>();
        previousButton = dialogueBoxPrefab.transform.Find("Previous Button").gameObject.GetComponent<Button>();
        initiateDialogue();
    }

    // splits the level dialogues into a list containing a list of Tuples
    void initiateDialogue()
    {
        currentDialogueLevel = 0;
        currentLineNumber = 0;
        isComplete = false;
        saveDialogueProgress();
        List<string> levelDialogueList = dialogue.getDialogueStory();
        List<string> LDialogue;
        for (int i = 0; i < levelDialogueList.Count; i++)
        {
            LDialogue = splitLevelDialogue(levelDialogueList[i]);
            TupleDialogue[i] = convertToTupleList(LDialogue);
        }
    }

    bool checkValidNextDialogue()
    {
        if (currentDialogueLevel < levelText.Count)
        {
            if ((currentLineNumber + 1) < TupleDialogue[currentDialogueLevel].Count)
            {
                return true;
            }
            else if ((currentDialogueLevel + 1) < levelText.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    bool checkValidPreviousDialogue()
    {
        if (currentDialogueLevel >= 0)
        {
            if ((currentLineNumber - 1) >= 0)
            {
                return true;
            }
            else if ((currentDialogueLevel - 1) >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    // fetches the next dialogue from the Tuple depending on current line number
    private string NextDialogue()
    {
        if (checkValidNextDialogue())
        {
            List<Tuple<string, string>> currentTupleList = new List<Tuple<string, string>>();
            currentTupleList = TupleDialogue[currentDialogueLevel];
            currentLineNumber++;
            Tuple<string, string> currentTuple = currentTupleList[currentLineNumber];
            lastPersonTalked = currentTuple.Item1;
            string nextDialogue = currentTuple.Item2;
            saveDialogueProgress();
            return nextDialogue;
        }
        else
        {
            return null;
        }
    }

    // goes back to the previous dialogue using the saved dialogue level and line number
    private string PreviousDialogue()
    {
        if (checkValidPreviousDialogue())
        {
            List<Tuple<string, string>> currentTupleList = new List<Tuple<string, string>>();
            currentTupleList = TupleDialogue[currentDialogueLevel];
            Tuple<string, string> currentTuple = currentTupleList[currentLineNumber - 1];
            currentLineNumber--;
            lastPersonTalked = currentTuple.Item1;
            string previousDialogue = currentTuple.Item2;
            saveDialogueProgress();
            return previousDialogue;
        }
        else
        {
            return null;
        }
    }

    // splits a given level dialogue string into an array of dialogues (not sorted yet) and returns
    public List<string> splitLevelDialogue(string s)
    {
        levelText = new List<string>(s.Split('$'));
        return levelText;
    }

    // converts the given list of dialogue strings into a list of Tuples 
    public List<Tuple<string,string>> convertToTupleList(List<string> s) {
        List<Tuple<string,string>> dialogueList = new List<Tuple<string, string>>();
        for (int i = 0; i < s.Count; i++) {
            string[] dialogue = s[i].Split('%');
            string person = dialogue[0];
            string text = dialogue[1];
            dialogueList.Add(new Tuple<string, string>(person, text));
        }
        return dialogueList;
    }

    public void TestDialogueBox()
    {
        animator.SetBool("IsOpen", true);
        Debug.Log("Dialogue Box is Open");
    }

    public void StartDialogue()
    {
        animator.SetBool("IsOpen", true);
        StopAllCoroutines();
        Tuple<string, string> to_be_typed = TupleDialogue[currentDialogueLevel][currentLineNumber];
        string name = to_be_typed.Item1;
        string dialogue_text = to_be_typed.Item2;
        UpdateUI(name, dialogue_text);
        if (checkValidNextDialogue())
            nextButton.gameObject.SetActive(true);
    }

    public void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        GetComponent<NPCInteractManager>().isTalking = false;
        endCanvas.GetComponent<Animator>().SetBool("End", true);
    }

    // default update
    public void Update()
    {
        if (isTalking == true)
        {
            if (NextDialogue() != null)
            {
                nextButton.gameObject.SetActive(true);
            }
            nextButton.onClick.AddListener(() => UpdateUI(lastPersonTalked, NextDialogue()));
            if (PreviousDialogue() != null)
            {
                previousButton.gameObject.SetActive(true);
            }
            previousButton.onClick.AddListener(() => UpdateUI(lastPersonTalked, PreviousDialogue()));
        }
        if (NextDialogue() == null)
        {
            isTalking = false;
            saveDialogueProgress();
        }
    }

    public void UpdateUI(string speaker, string text)
    {
        // To be updated later
        Color speakerColor = Color.black;
        dialogueBoxPrefab.GetComponentInChildren<Image>().color = speakerColor;
        StartCoroutine(TypeSentence(speaker, text));
    }

    IEnumerator TypeSentence(string speaker, string text)
    {
        textComponent.text = "";
        string name = speaker;
        string dialogue_text = text;
        string to_display_first = name + ": ";
        textComponent.text += to_display_first;
        foreach (char letter in dialogue_text.ToCharArray())
        {
            textComponent.text += letter;
            yield return new WaitForSeconds(0.02f);
        }
    }

    // Payam F: added this function to support the save system
    public void saveDialogueProgress()
    {
        dialogueProgress.currentDialogueLevel = currentDialogueLevel;
        dialogueProgress.currentLineNumber = currentLineNumber;
        dialogueProgress.lastPersonTalked = lastPersonTalked;
        dialogueProgress.isTalking = isTalking;
        dialogueProgress.isComplete = isComplete;
    }
}
