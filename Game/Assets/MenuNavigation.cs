using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuNavigation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateSubMenu (int index)
    {
        DeactivateAllSubMenus();
        if (index < transform.childCount)
            transform.GetChild(index).gameObject.SetActive(true);
    }

    public void DeactivateAllSubMenus()
    {
        for (int i=0; i<transform.childCount; i++)
            transform.GetChild(i).gameObject.SetActive(false);
    }
}
