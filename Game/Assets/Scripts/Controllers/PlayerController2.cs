using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public float speed = 2f;

    private Vector3 moveDirection;
    private Rigidbody2D playerRigidBody;
    private CharacterAnimator animator;
    private CapsuleCollider2D playerCollider;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<CharacterAnimator>();
        playerCollider = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector3(horizontal, vertical).normalized;
        animator.setDirection(horizontal, vertical);
    }

    void FixedUpdate()
    {
        playerRigidBody.velocity = moveDirection * speed;
    }

}
