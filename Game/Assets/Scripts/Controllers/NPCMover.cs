using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMover : MonoBehaviour
{
    
    WaveConfig waveConfig;
    List<Transform> wayPoints;
    List<Transform> entPoints;
    List<Transform> extPoints;

    float movespeed;
    int wayPointIndex = 0;
    bool jumpable = true;
    int onDoorIndex = 0;
    

    private CharacterAnimator animator;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<CharacterAnimator>();
        wayPoints = waveConfig.GetWayPoints();
        transform.position = wayPoints[wayPointIndex].transform.position;
        movespeed = waveConfig.GetMoveEnemySpeed();
        entPoints = waveConfig.GetEntPoints();
        extPoints = waveConfig.GetExtPoints();
    }


    public void SetWaveConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }



    private void Move()
    {
        if (wayPointIndex <= wayPoints.Count - 1)
        {
            bool onDoor = doorCheck();
            if (jumpable && onDoor)
            {
                jumpPoint(onDoorIndex);
                onDoorIndex += 1;
            }
            var targetPosition = wayPoints[wayPointIndex].transform.position;
            var movementThisFrame = movespeed * Time.deltaTime;
            Vector2 move = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);
            transform.position = move;
            animator.setDirection(Mathf.Round(targetPosition.x - move.x), Mathf.Round(targetPosition.y - move.y));
            if (transform.position == targetPosition)
            {
                wayPointIndex++;
                jumpable = true;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    //  checks if character is in range to interact with door
    //  written by: Methasit T.
    private bool doorCheck()
    {
        for (int i = 0; i < entPoints.Count; i++)
        {
            if (Vector3.Distance(transform.position, entPoints[i].transform.position) < 1.2)
            {
                return true;
            }
        }

        return false;
    }

    //  jumps from door entry to exit
    // written by Methasit T.
    private void jumpPoint(int i)
    {
        transform.position = extPoints[i].transform.position;
        wayPointIndex++;
        jumpable = false;
    }

}