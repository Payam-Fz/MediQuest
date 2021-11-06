using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="LevelDialogue")]
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