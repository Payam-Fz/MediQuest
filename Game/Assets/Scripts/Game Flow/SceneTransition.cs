using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransition : MonoBehaviour, IInteractable
{
    [SerializeField] SceneLoader sceneLoader;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact() 
    {

    }

    public void ManualHighlight() 
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerTag")
        {
            Debug.Log("Player go through the wall");
            sceneLoader.LoadScene(2);
        }
    }
}
