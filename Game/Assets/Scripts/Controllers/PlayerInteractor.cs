using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using TMPro;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    //Collider2D overlap;
    bool canInteract = false;
    Collider2D interactiveCollider;
    [SerializeField] private TextMeshProUGUI interactText;
    
    void Start()
    {
        //overlap = Physics2D.OverlapCircle(transform.position, 5f, 8);
        //overlap.isTrigger = enabled;
        interactText.text = "";
    }

    private void Update()
    {
        if(canInteract && Input.GetKeyDown(KeyCode.E))
        {
            interactiveCollider.GetComponent<IInteractable>().Interact();
            interactText.text = "";
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<IInteractable>() != null)
        {
            interactiveCollider = collision;
            canInteract = true;
            if(collision.gameObject.GetComponent<AllIn1Shader>() != null)
            {
                interactiveCollider.GetComponent<Renderer>().material.SetFloat("_OutlineAlpha", 0.8f);
            }
            else
            {
                collision.gameObject.GetComponent<IInteractable>().ManualHighlight();
            }
            interactText.text = "Press [E] to interact";
            Debug.Log("Interactive Object Detected!");
        }

        if(collision.gameObject.GetComponent<IAudioObject>() != null)
        {
            collision.gameObject.GetComponent<IAudioObject>().PlaySound();
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<IInteractable>() != null)
        {
            interactiveCollider = collision;
            canInteract = false;
            if (collision.gameObject.GetComponent<AllIn1Shader>() != null)
            {
                interactiveCollider.GetComponent<Renderer>().material.SetFloat("_OutlineAlpha", 0f);
            }
            else
            {
                collision.gameObject.GetComponent<IInteractable>().ManualHighlight();
            }
            //interactiveCollider.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            interactText.text = "";
            Debug.Log("Leaving Interactive Object!");
        }

        if (collision.gameObject.GetComponent<IAudioObject>() != null)
        {
            collision.gameObject.GetComponent<IAudioObject>().StopSound();
        }
    }

            //interactiveCollider.gameObject.GetComponent<SpriteRenderer>().material.shader = AllIn1Shader.Set
            //Color interactiveColor = interactiveCollider.gameObject.GetComponent<SpriteRenderer>().color;
            //interactiveCollider.gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
            //interactText.text = "Press [E] to interact";


    /*private IEnumerator PlayText(string text, string textHolder)
    {
        var charText = text.ToCharArray();
        foreach (char c in charText)
        {
            textHolder += c;
        }
            yield return new WaitForSeconds(0.01f);
        textHolder = text;
    }*/

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<IInteractive>() != null)
        {
            Debug.Log("interactive!");
        }
    }*/


    /*private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<IInteractive>() != null)
        {
            Debug.Log("pp");
            if (Input.GetKeyDown(KeyCode.E))
            {
                collision.gameObject.GetComponent<IInteractive>().Interact();
                Debug.Log("Interacted!");
            }
        }
    }*/
}
