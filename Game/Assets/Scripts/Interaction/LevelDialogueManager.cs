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
    //[SerializeField] string dataPath;
    //[SerializeField] Animator animator;
    //[SerializeField] GameObject journal;
    [SerializeField] GameObject dialogueBox;
    //[SerializeField] GameObject endCanvas;
    
    private TextMeshProUGUI textComponent;
    private Button nextButton;
    private Button previousButton;
    private Animator animator;
    private LevelDialogue dialogue;
    private DialogueProgress dialogueProgress;

    private int currentDialogueLevel;
    private int currentLineNumber;
    private string lastPersonTalked;
    private bool isTalking;
    private bool isComplete;

    private List<List<Tuple<string, string>>> TupleDialogue;
    List<string> levelText = new List<string>();

    private Color dialogueBoxPlayerColor = new Color(0.7f, 0.9f, 0.43f);
    private Color dialogueBoxOthersColor = new Color(0.7f, 0.35f, 0.43f);

    // Start is called before the first frame update
    void Start()
    {
        dialogue = gameObject.GetComponent<DataContainer>().levelDialogue;
        dialogueProgress = gameObject.GetComponent<DataContainer>().dialogueProgress;
        textComponent = dialogueBox.GetComponentInChildren<TextMeshProUGUI>();
        nextButton = dialogueBox.transform.Find("Next Button").gameObject.GetComponent<Button>();
        previousButton = dialogueBox.transform.Find("Previous Button").gameObject.GetComponent<Button>();
        animator = dialogueBox.GetComponent<Animator>();
        TupleDialogue = new List<List<Tuple<string, string>>>();
        LoadDialogue();
    }

    // splits the level dialogues into a list containing a list of Tuples
    private void LoadDialogue()
    {
        currentDialogueLevel = dialogueProgress.currentDialogueLevel;
        currentLineNumber = dialogueProgress.currentLineNumber;
        lastPersonTalked = dialogueProgress.lastPersonTalked;
        isTalking = dialogueProgress.isTalking;
        isComplete = dialogueProgress.isComplete;

        List<string> levelDialogueList = dialogue.getDialogueStory();
        List<string> LDialogue;
        for (int i = 0; i < levelDialogueList.Count; i++)
        {
            LDialogue = splitLevelDialogue(levelDialogueList[i]);
            TupleDialogue.Add(convertToTupleList(LDialogue));
        }
    }

    bool checkValidNextDialogue() {
        if (currentDialogueLevel < levelText.Count) {
            if ((currentLineNumber + 1) < TupleDialogue[currentDialogueLevel].Count) {
                return true;
            } else if ((currentDialogueLevel + 1) < dialogue.getDialogueStory().Count) {
                return true;
            } else {
                return false;
            }
        } else {
            return false;
        }
    }

    bool checkValidPreviousDialogue() {
        if (currentDialogueLevel >= 0) {
            if ((currentLineNumber - 1) >= 0) {
                return true;
            }
            else if ((currentDialogueLevel - 1) >= 0) {
                return true;
            }
            else {
                return false;
            }
        } else {
            return false;
        }
    }
    // fetches the next dialogue from the Tuple depending on current line number
    // Also, updates the currentLineNumber and lastPersonTalked
    private string GetNextDialogue() {
        List<Tuple<string, string>> currentTupleList = TupleDialogue[currentDialogueLevel];
        currentLineNumber++;
        Tuple<string, string> currentTuple = currentTupleList[currentLineNumber];
        lastPersonTalked = currentTuple.Item1;
        string nextDialogue = currentTuple.Item2;
        saveDialogueProgress();
        return nextDialogue;
    }
    public void OpenDialogue()
    {
        dialogueBox.SetActive(true);
        nextButton.onClick.AddListener(onClickNextDialogue);
        previousButton.onClick.AddListener(onClickPreviousDialogue);
        animator.SetBool("IsOpen", true);
        StopAllCoroutines();
        Tuple<string, string> to_be_typed = TupleDialogue[currentDialogueLevel][currentLineNumber];
        string name = to_be_typed.Item1;
        string dialogue_text = to_be_typed.Item2;
        UpdateUI(name, dialogue_text);
        if (!checkValidNextDialogue())
        {
            nextButton.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Close X";
        }
        if (checkValidPreviousDialogue())
        {
            previousButton.gameObject.SetActive(true);
        }
        else
        {
            previousButton.gameObject.SetActive(false);
        }
    }

    private void CloseDialogue()
    {
        animator.SetBool("IsOpen", false);
        nextButton.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Next >";
        nextButton.onClick.RemoveAllListeners();
        previousButton.onClick.RemoveAllListeners();
        dialogueBox.SetActive(false);

        GetComponent<NPCInteractManager>().isTalking = false;
        saveDialogueProgress();
        //endCanvas.GetComponent<Animator>().SetBool("End", true);
    }
    public void onClickNextDialogue()
    {
        if (checkValidNextDialogue())
        {
            Debug.Log("valid next dialogue. line: " + currentLineNumber);
            string next_d = GetNextDialogue();
            UpdateUI(lastPersonTalked, next_d);
            previousButton.gameObject.SetActive(true);
            //Debug.Log("checking next valid!");
            if (!checkValidNextDialogue())
            {
                //Debug.Log("Next still valid!");
                nextButton.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Close X";
            }
        } else
        {
            CloseDialogue();
            Debug.Log("Invalid next dialogue, closing. line: " + currentLineNumber );
        }
    }

    public void onClickPreviousDialogue()
    {
        if (checkValidPreviousDialogue())
        {
            string prev_d = PreviousDialogue();
            UpdateUI(lastPersonTalked, prev_d);
            nextButton.gameObject.SetActive(true);
            if (!checkValidPreviousDialogue())
            {
                previousButton.gameObject.SetActive(false);
            }
        } 
    }

    // goes back to the previous dialogue using the saved dialogue level and line number
    private string PreviousDialogue() {
        if (checkValidPreviousDialogue()) {
            List<Tuple<string, string>> currentTupleList = TupleDialogue[currentDialogueLevel];
            currentLineNumber--;
            Tuple<string, string> currentTuple = currentTupleList[currentLineNumber];
            lastPersonTalked = currentTuple.Item1;
            string previousDialogue = currentTuple.Item2;
            saveDialogueProgress();
            return previousDialogue;
        } else {
            return null;
        }
    }

    // splits a given level dialogue string into an array of dialogues (not sorted yet) and returns
    public List<string> splitLevelDialogue(string s)
    {
        //access begins from index 1
        levelText = new List<string>(s.Split('$'));
        return levelText;
    }

    // converts the given list of dialogue strings into a list of Tuples 
    public List<Tuple<string,string>> convertToTupleList(List<string> s) {
        List<Tuple<string,string>> dialogueList = new List<Tuple<string, string>>();
        //access begins from index 0
        for (int i = 1; i < s.Count; i++) {
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

    public void UpdateUI(string speaker, string text)
    {
        StopAllCoroutines();
        if (speaker.Equals("Player"))
        {
            dialogueBox.GetComponentInChildren<Image>().color = dialogueBoxPlayerColor;
        } else
        {
            dialogueBox.GetComponentInChildren<Image>().color = dialogueBoxOthersColor;
        }
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
