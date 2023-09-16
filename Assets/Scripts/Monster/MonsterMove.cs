using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MonsterMove : MoveModule<SkeletonAnimation>
{
    void Start()
    {
        target = FindAnyObjectByType<PlayerMove>().transform;
        animator = GetComponent<SkeletonAnimation>();
        rigidBody = GetComponent<Rigidbody2D>();
    }


    void Update() => Move();

    public override void Move() //몬스터 이동
    {
        if (target != null)
        {
            if (!isAtk && !isDead)
            {
                if (!isChased)
                {
                    animator.AnimationState.SetAnimation(0, "Walk", true);
                    isChased = true;
                }
                Vector3 targetDirection = (target.position - transform.position).normalized;
                Flip(targetDirection.x);
                transform.position += targetDirection * moveSpeed * Time.deltaTime;
            }
        }
    }

    public override void Flip(float dir) //몬스터 방향 전환 시 스프라이트 반전
    {
        if (dir <= 0) transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        else transform.rotation = Quaternion.identity;
    }
    private void OnTriggerEnter2D(Collider2D collision) //플레이어가 공격범위 내에 들어왔을 때
    {
        if (collision.CompareTag("Player")) isAtk = true;
    }
    private void OnTriggerExit2D(Collider2D collision) //플레이어가 공격범위 밖으로 벗어났을 때
    {
        if (collision.CompareTag("Player"))
        {
            isChased = false;
            isAtk = false;
        }
    }
}
