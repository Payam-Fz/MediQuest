using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] float musicDelay = 2f;
    private void Awake()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);

        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

        Debug.Log("Scene Loaded");
    }
    
    private void Start()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.PlayDelayed(musicDelay);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if(collision.GetComponent<>)
    }
}
