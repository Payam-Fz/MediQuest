using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV : MonoBehaviour, IInteractive
{
    SpriteRenderer tvSprite;
    [SerializeField] Sprite tvOn;
    [SerializeField] Sprite tvOff;

    [SerializeField] GameObject tempNPC;

    
    void Start()
    {
        tvSprite = GetComponent<SpriteRenderer>();
    }
    
    public void Interact()
    {
        if(tvSprite.sprite == tvOff)
        {
            tvSprite.sprite = tvOn;
            tempNPC.transform.localScale = new Vector3(1, 1, 1);
        } 
        else if(tvSprite.sprite == tvOn)
        {
            tvSprite.sprite = tvOff;
        }
    }

    public void ManualHighlight()
    {
        //throw new System.NotImplementedException();
        Debug.Log("TV Highlight is not implemented.");
    }
}
