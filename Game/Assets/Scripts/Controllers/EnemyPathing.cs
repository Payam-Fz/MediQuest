using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{

    WaveConfig waveConfig;
    List<Transform> wayPoints;

    float movespee;
    int wayPointIndex = 0;

    private CharacterAnimator animator;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<CharacterAnimator>();
        wayPoints = waveConfig.GetWayPoints();
        transform.position = wayPoints[wayPointIndex].transform.position;
        movespee = waveConfig.GetMoveEnemySpeed();
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
            var targetPosition = wayPoints[wayPointIndex].transform.position;
            var movementThisFrame = movespee * Time.deltaTime;
            Vector2 move = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);
            transform.position = move;
            animator.setDirection(Mathf.Round(targetPosition.x - move.x), Mathf.Round(targetPosition.y - move.y));
            if (transform.position == targetPosition)
            {
                wayPointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }


}