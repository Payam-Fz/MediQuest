using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float playerSpeed = 10f;
    private Vector2 playerInput;

    private Rigidbody2D playerRb;
    private CapsuleCollider2D playerCollider;
    
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<CapsuleCollider2D>();

    }

    void Update()
    {
        playerInput.x = Input.GetAxisRaw("Horizontal");
        playerInput.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        playerRb.transform.Translate(playerInput * playerSpeed * Time.fixedDeltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Start Room")
        {
            playerRb.transform.position = new Vector3(-11.5f, 0.75f); //(-12.5f, 0.5f) <steph's scene
        }
        else if (collision.gameObject.name == "End Room")
        {
            playerRb.transform.position = new Vector3(-7.25f, 0.75f);
        }
    }














    /*
    private float playerSpeed = 10f;
    private Rigidbody2D playerRb;
    private CircleCollider2D playerCollider;
    private Vector2 playerInput;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        playerInput.x = Input.GetAxisRaw("Horizontal");
        playerInput.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        playerRb.transform.Translate(playerInput * Time.fixedDeltaTime * playerSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Start Room")
        {
            playerRb.transform.position = new Vector3(-11f, 0.75f);
        } 
        else if (collision.gameObject.name == "End Room")
        {
            playerRb.transform.position = new Vector3(-7.25f, 0.75f);
        }
    }
    */
}
