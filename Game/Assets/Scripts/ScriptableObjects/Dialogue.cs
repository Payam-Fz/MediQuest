using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Dialogue")]
public class Dialogue : ScriptableObject
{
    [TextArea(10, 19)] [SerializeField] public string dialogueText;
    [SerializeField] Dialogue[] nextDialogue;
    
    public string GetDialogueStory()
    {
        return dialogueText;
    }
    public Dialogue[] GetNextDialogue()
    {
        return nextDialogue; 
    }
    
    
    
  



}
