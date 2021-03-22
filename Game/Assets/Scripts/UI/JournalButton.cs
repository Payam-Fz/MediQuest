using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JournalButton : MonoBehaviour
{
    Button journalButton;
    [SerializeField] string journalBranch;
    [SerializeField] int buttonPage;
    [SerializeField] int targetPage;
    
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
