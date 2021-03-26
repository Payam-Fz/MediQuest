using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeMachine : MonoBehaviour, IInteractive
{
    SpriteRenderer machineSprite;
    [SerializeField] Sprite lvl0;
    [SerializeField] Sprite lvl1;
    [SerializeField] Sprite lvl2;
    [SerializeField] Sprite lvl3;
    [SerializeField] Sprite lvl4;
    [SerializeField] Sprite lvl5;
    AudioSource machineSound;

    bool machineUsed = false;

    private void Start()
    {
        machineSprite = GetComponent<SpriteRenderer>();
        machineSound = GetComponent<AudioSource>();
    }

    public void Interact()
    {
        if (!machineUsed)
        {
            StartCoroutine(AnimateCoffee(1f));
            machineUsed = true;
        }
    }

    IEnumerator AnimateCoffee(float timeDelay)
    {
        machineSound.Play();
        
        machineSprite.sprite = lvl1;
        yield return new WaitForSeconds(timeDelay);
        machineSprite.sprite = lvl2;
        yield return new WaitForSeconds(timeDelay);
        machineSprite.sprite = lvl3;
        yield return new WaitForSeconds(timeDelay);
        machineSprite.sprite = lvl4;
        yield return new WaitForSeconds(timeDelay);
        machineSprite.sprite = lvl5;
    }

    public void ManualHighlight()
    {
        Debug.Log("Coffee machine highlighted!");
        //throw new System.NotImplementedException();
    }

}
