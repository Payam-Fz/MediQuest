using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 2f;

    private Vector3 moveDirection;
    private Rigidbody2D playerRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector3(horizontal, vertical).normalized;
        SetAnimatorDirection(horizontal, vertical);
    }

    void FixedUpdate()
    {
        playerRigidBody.velocity = moveDirection * speed;
    }

    void SetAnimatorDirection(float horizontal, float vertical)
    {
        Direction direction;


        if (horizontal < 0)
        {
            if (vertical < 0)
            {
                direction = Direction.LeftFront;
            }
            else if (vertical > 0)
            {
                direction = Direction.LeftBack;
            }
            else      // vertical == 0
            {
                direction = Direction.Left;
            }
        }
        else if (horizontal == 0)
        {
            if (vertical < 0)
            {
                direction = Direction.Front;
            }
            else if (vertical > 0)
            {
                direction = Direction.Back;
            }
            else      // vertical == 0
            {
                direction = Direction.Standing;
            }
        }
        else // horizontal > 0
        {
            if (vertical < 0)
            {
                direction = Direction.RightFront;
            }
            else if (vertical > 0)
            {
                direction = Direction.RightBack;
            }
            else      // vertical == 0
            {
                direction = Direction.Right;
            }
        }
        GetComponentInChildren<Animator>().SetInteger("Direction", (int)direction);
    }
}
