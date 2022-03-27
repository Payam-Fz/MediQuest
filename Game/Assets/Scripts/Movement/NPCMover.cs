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
    bool moveable = true;
    int onDoorIndex;


    private CharacterAnimator animator;
    AudioSource doorSFX;
    GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<CharacterAnimator>();
        wayPoints = waveConfig.GetWayPoints();
        transform.position = wayPoints[wayPointIndex].transform.position;
        movespeed = waveConfig.GetMoveEnemySpeed();
        entPoints = waveConfig.GetEntPoints();
        extPoints = waveConfig.GetExtPoints();
        doorSFX = GameObject.FindGameObjectWithTag("Door").GetComponent<AudioSource>();
        gameObject.AddComponent<AudioSource>();
        GetComponent<AudioSource>().clip = doorSFX.clip;
        GetComponent<AudioSource>().volume = 0.326f;
        GetComponent<AudioSource>().pitch = 0.84f;
        player = GameObject.FindGameObjectWithTag("Player");
    }


    public void SetWaveConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveable == true)
        {
            Move();
        }
    }



    private void Move()
    {
        if (wayPointIndex <= wayPoints.Count - 1)
        {
            bool onDoor = doorCheck();
            if (jumpable && onDoor)
            {
                StartCoroutine(doorEntry());
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
                onDoorIndex = i;
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

        if (NPCPlayerRange() && GetComponent<AudioSource>().isPlaying == false)
        {
            GetComponent<AudioSource>().Play();
        }

        wayPointIndex++;
        jumpable = false;
    }

    //Checks if NPC near player, true if near
    private bool NPCPlayerRange()
    {
        if (Vector3.Distance(player.transform.position, transform.position) > 7)
        {
            return false;
        }
        return true;
    }

    //entire door movement process, including pauses
    IEnumerator doorEntry()
    {
        moveable = false;

        yield return new WaitForSeconds(0.3f);

        jumpPoint(onDoorIndex);
        //onDoorIndex += 1;

        yield return new WaitForSeconds(0.3f);

        moveable = true;
    }
}