using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JournalButton : MonoBehaviour
{
    Button journalButton;
    [SerializeField] string journalBranch;
    [SerializeField] public int buttonPage;
    [SerializeField] public int targetPage;
    Animator JournalAnimator;
    
    // Start is called before the first frame update
    void Start()
    {
        journalButton = gameObject.GetComponent<Button>();
        if(transform.parent.name == "Illnesses")
        {
            journalBranch = "Illness";
        }
        else
        {
            journalBranch = "Injury";
        }

        JournalAnimator = transform.parent.parent.GetComponent<Animator>();
        //JournalController.journalButtons.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
