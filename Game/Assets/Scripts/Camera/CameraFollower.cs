using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    private Transform targetTransform;

    [SerializeField] float smoothSpeed = 0.125f;
    [SerializeField] Vector3 offset;

    void Start()
    {
        targetTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        Vector3 endPos = targetTransform.position + offset;
        Vector3 smoothPos = Vector3.Lerp(transform.position, endPos, smoothSpeed * Time.deltaTime);
        transform.position = smoothPos;
    }
}
