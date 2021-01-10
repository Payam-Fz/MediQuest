﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SystemButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Canvas systemCanvas;
    GameObject[] systemDiagrams;

    private void Start()
    {
        systemCanvas = GetComponentInParent<Canvas>();
        systemDiagrams = GetComponentInParent<SystemPicker>().bodySystems;
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        StartCoroutine(GenericDelay());

        foreach (var system in systemDiagrams)
        {
            if(system.name != transform.parent.name)
            {
                system.GetComponent<Image>().color = new Color(1, 1, 1, 0.2f);
                system.GetComponent<Canvas>().sortingOrder = 5;
            }
            else
            {
                system.GetComponent<Image>().color = new Color(1, 1, 1, 1f);
            }
        }

        systemCanvas.sortingOrder = 6;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StartCoroutine(GenericDelay());
        
        if(eventData.selectedObject != null)
        {
            foreach(var system in systemDiagrams)
            {
                if(system != eventData.selectedObject.transform.parent)
                {
                    system.GetComponent<Image>().color = new Color(1, 1, 1, 0.2f);
                    system.GetComponent<Canvas>().sortingOrder = 5;
                }
            }
            eventData.selectedObject.transform.parent.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            eventData.selectedObject.transform.parent.GetComponent<Canvas>().sortingOrder = 6;
        }
    }

    IEnumerator GenericDelay()
    {
        yield return new WaitForSeconds(0.3f);
    }

}
