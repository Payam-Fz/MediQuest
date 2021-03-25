using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;
using UnityEngine.EventSystems;

public class JournalController : MonoBehaviour
{
    [SerializeField] Animator journalAnimator;
    public static List<JournalButton> journalButtons = new List<JournalButton>();
    
    
    // Start is called before the first frame update
    void Start()
    {
        journalButtons.AddRange(Resources.FindObjectsOfTypeAll(typeof(JournalButton)) as JournalButton[]);
        Debug.Log("No. of Journal Buttons: " + journalButtons.Count);
        StartCoroutine(OpenPageDelay());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NavigateJournal()
    {
        StartCoroutine(PageFlip());        
    }

    IEnumerator OpenPageDelay()
    {
        yield return new WaitForSeconds(1f);
        foreach(var button in journalButtons)
        {
            if(button.buttonPage == 0)
            {
                button.gameObject.SetActive(true);
            }
        }
    }

    IEnumerator PageFlip()
    {
        journalAnimator.ResetTrigger("PageFlip");

        int currentPage = EventSystem.current.currentSelectedGameObject.GetComponent<JournalButton>().buttonPage;
        int currentTargetPage = EventSystem.current.currentSelectedGameObject.GetComponent<JournalButton>().targetPage;
        Debug.Log(currentTargetPage);

        foreach (var button in journalButtons)
        {
            if (button.buttonPage == currentPage)
            {
                button.gameObject.SetActive(false);
            }
        }

        journalAnimator.SetTrigger("PageFlip");

        yield return new WaitForSeconds(0.5f);

        foreach (var button in journalButtons)
        {
            Debug.Log(button.buttonPage);
            if (button.buttonPage == currentTargetPage)
            {
                Debug.Log(button.name);
                button.gameObject.SetActive(true);
            }
        }
    }

}
