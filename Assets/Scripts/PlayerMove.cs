using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour 
{
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Rigidbody2D rigidBody;
    public VariableJoystick variableJoystick;
    public float MoveSpeed;
    private float moveSpeed { get => MoveSpeed; set => MoveSpeed = value; }

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        float horizontal = variableJoystick.Horizontal;
        float vertical = variableJoystick.Vertical;

        Vector3 moveDirection = new Vector3(horizontal, vertical).normalized;
        Vector3 newPosition = transform.position + moveDirection * moveSpeed * Time.fixedDeltaTime;
        rigidBody.MovePosition(newPosition);
        Flip(horizontal);
        RunAnim(horizontal, vertical);
    }

    void Flip(float horizontal)
    {
        if(Mathf.Abs(horizontal) > 0) spriteRenderer.flipX = horizontal < 0;
    }

    void RunAnim(float h, float v)
    {
        if(h != 0 || v != 0) animator.SetBool("IsMove", true);
        else animator.SetBool("IsMove", false);
    }
}
