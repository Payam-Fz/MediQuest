using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPanner : MonoBehaviour
{
    private Camera mainCamera;
    private CircleCollider2D playerCollider;
    private Vector3 startCamera;
    private Vector3 endCamera = new Vector3(-17.75f, 0, -10f);
    [SerializeField] private float panDuration;

    void Start()
    {
        mainCamera = GameObject.FindObjectOfType<Camera>();
        startCamera = mainCamera.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   

    private IEnumerator CameraPan(Vector3 startPos, Vector3 endPos)
    {
        float t = 0.0f;
        while (t < 1.0f)
        {
            t += Time.deltaTime; //* (Time.timeScale / panDuration);
            mainCamera.transform.position = Vector3.Lerp(startPos, endPos, t);
            yield return 0;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Start Room" && collision is BoxCollider2D)
        {
            //StartCoroutine(CameraPan(transform.position, endCamera));
            StartCoroutine(CameraPan(startCamera, endCamera));
        }
        else if (collision.gameObject.name == "End Room" && collision is BoxCollider2D)
        {
            //StartCoroutine(CameraPan(transform.position, startCamera));
            StartCoroutine(CameraPan(endCamera, startCamera));
        }
    }
}
