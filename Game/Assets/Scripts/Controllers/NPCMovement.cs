using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    [SerializeField] List<Transform> waypoints;
    [SerializeField] float speed = 2f;

    private CharacterAnimator animator;

    int waypointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;
        animator = GetComponent<CharacterAnimator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (waypointIndex < waypoints.Count)
        {
            var targetposition = waypoints[waypointIndex].transform.position;
            var movementThisFrame = speed * Time.deltaTime;
            Vector3 move = Vector2.MoveTowards(transform.position, targetposition, movementThisFrame);
            transform.position = move;
            animator.setDirection(Mathf.Round(targetposition.x - move.x), Mathf.Round(targetposition.y - move.y));


            if (transform.position == targetposition)
            {
                waypointIndex++;
            }
        } else
        {
            Object.Destroy(gameObject);
        }
    }
}
