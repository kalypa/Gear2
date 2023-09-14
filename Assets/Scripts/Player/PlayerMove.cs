using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MoveModule<Animator>
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private VariableJoystick variableJoystick;
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

    public override void Move()
    {
        if (!GameManager.Inst.playerTransform.isTransform)
        {
            float horizontal = variableJoystick.Horizontal;
            float vertical = variableJoystick.Vertical;

            Vector3 moveDirection = new Vector3(horizontal, vertical).normalized;
            Vector3 newPosition = transform.position + moveDirection * moveSpeed * Time.fixedDeltaTime;
            rigidBody.MovePosition(newPosition);
            Flip(horizontal);
            if (horizontal == 0 && vertical == 0) FindClosestEnemy();
            else RunAnim(horizontal, vertical);
        }
    }

    public override void Flip(float horizontal)
    {
        if(Mathf.Abs(horizontal) > 0) spriteRenderer.flipX = horizontal < 0;
    }

    void RunAnim(float h, float v)
    {
        isAtk = false;
        isChased = false;
        if (h != 0 || v != 0) animator.SetBool("IsMove", true);
        else animator.SetBool("IsMove", false);
    }

    void FindClosestEnemy()
    {
        if(!GameManager.Inst.playerTransform.isTransform)
        {
            if (!isChased)
            {
                animator.SetBool("IsMove", true);
                isChased = true;
            }
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Monster");
            float closestDistance = Mathf.Infinity;
            Transform closestEnemy = null;

            foreach (GameObject enemy in enemies)
            {
                float distance = Vector3.Distance(transform.position, enemy.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestEnemy = enemy.transform;
                }
            }
            target = closestEnemy;
            Vector3 targetDirection = (closestEnemy.position - transform.position).normalized;
            if (!isAtk) transform.position += targetDirection * moveSpeed * Time.deltaTime;
            Flip(targetDirection.x);
            FindEnemy();
        }
    }

    void FindEnemy()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, GetComponent<PlayerAtk>().attackRadius);

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Monster"))
            {
                GetComponent<PlayerAtk>().Attack();
                isAtk = true;
            }
        }
    }
}
