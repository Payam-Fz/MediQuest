using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockoutMachineInteractManager : MonoBehaviour, IInteractable
{
    SpriteRenderer clockoutMachine;
    [SerializeField] Sprite clockoutOn;
    [SerializeField] Sprite clockoutOff;

    
    // Start is called before the first frame update
    void Start()
    {
        clockoutMachine = GetComponent<SpriteRenderer>();
    }

    public void Interact()
    {
        if (clockoutMachine.sprite == clockoutOff)
        {
            clockoutMachine.sprite = clockoutOn;
        }
        else if (clockoutMachine.sprite == clockoutOn)
        {
            clockoutMachine.sprite = clockoutOff;
        }
    }

    public void ManualHighlight()
    {
        throw new System.NotImplementedException();
    }
}
