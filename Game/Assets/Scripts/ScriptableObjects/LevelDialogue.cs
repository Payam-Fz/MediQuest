using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Stores the dialogue in separate levels
 * Author:     Yan W @ 2021-10-30
 */
[CreateAssetMenu(fileName = "LevelDialogue", menuName = "CodeBlue/Character/LevelDialogue", order = 1)]
public class LevelDialogue : ScriptableObject
{
    [Header("Level Dialogues")]
    [TextArea(10, 19)] [SerializeField] public List<string> dialogueText = new List<string>();

    [Header("Follow on")]
    public LevelDialogue[] endDialogue;

    public List<string> getDialogueStory()
    {
        return dialogueText;
    }

    public LevelDialogue[] GetEndDialogues()
    {
        return endDialogue;
    }
}