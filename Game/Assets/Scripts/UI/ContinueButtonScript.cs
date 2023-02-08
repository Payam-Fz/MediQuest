using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinueButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        if (SaveLoadSystem.CheckSavePresent())
        {
            Debug.Log("Game save found");
            gameObject.GetComponent<Button>().interactable = true;
        }
    }

}
