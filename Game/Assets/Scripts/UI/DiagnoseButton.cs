using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DiagnoseButton : MonoBehaviour
{
    [SerializeField] Button[] systemButtons;
    Button button;

    void Start()
    {
        foreach (var button in systemButtons)
        {
            button.onClick.AddListener(delegate { ShowButton(); });
            Debug.Log("Button " + button.name + "has been attached with ShowButton();");
        }

        button = GetComponent<Button>();
        button.image.color = new Color(1, 1, 1, 0);
        button.interactable = false;
        gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "";
    }


    void ShowButton()
    {
        if (!button.interactable)
        {
            button.interactable = true;
            button.image.color = new Color(1, 1, 1, 1);
            gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "CONTINUE";
        }
    }
}
