using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector2 moveDirection;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    public Sprite spriteUp;
    public Sprite spriteDown;
    public Sprite spriteLeft;
    public Sprite spriteRight;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        ProcessInputs();
        ChangeSpriteDirection();
    }

    void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    void ChangeSpriteDirection()
    {
        if (moveDirection.x > 0)
        {
            spriteRenderer.sprite = spriteRight;
        }
        else if (moveDirection.x < 0)
        {
            spriteRenderer.sprite = spriteLeft;
        }
        else if (moveDirection.y > 0)
        {
            spriteRenderer.sprite = spriteUp;
        }
        else if (moveDirection.y < 0)
        {
            spriteRenderer.sprite = spriteDown;
        }
    }
}