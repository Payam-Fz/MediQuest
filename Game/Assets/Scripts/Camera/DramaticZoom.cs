using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DramaticZoom : MonoBehaviour
{
    Camera mainCam;
    Vector3 focalPoint;
    Vector3 focalMagnitude;

    void Start()
    {
        mainCam = GetComponent<Camera>();
        focalPoint = new Vector3(0.5f, -15.38f, -10f);
        focalMagnitude = focalPoint - transform.position;

        StartCoroutine(ZoomAndPan());
    }

    IEnumerator ZoomAndPan()
    {
        yield return new WaitForSeconds(1.5f);

        for (int i = 0; i < 99; i++)
        {
            if (transform.position != focalPoint)
            {
                transform.position += focalMagnitude / 80;
            }
            if (mainCam.orthographicSize > 0.8f)
            {
                mainCam.orthographicSize -= (4.20f / 99);
            }

            yield return new WaitForSeconds(0.1f);
        }
    }
}
