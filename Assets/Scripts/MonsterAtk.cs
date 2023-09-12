using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAtk : MonoBehaviour
{
    public float attackRadius = 3f;
    private SkeletonAnimation animator;

    private bool canAttack = true;
    void Start()
    {
        animator = GetComponent<SkeletonAnimation>();
    }


    void Update()
    {
        FindEnemy();
    }
    void FindEnemy()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, attackRadius);

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                Attack();
            }
        }
    }

    public void Attack()
    {
        if (canAttack)
        {
            var gm = GameManager.Inst;
            canAttack = false;
            animator.AnimationState.SetAnimation(0, "Attack", true);
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, attackRadius);

            foreach (Collider2D collider in colliders)
            {
                if (collider.CompareTag("Monster")) collider.GetComponent<MonsterEvent>().Damaged(gm.monsterStats[gm.currentStage].hp, gm.playerStat.atk);
            }
            Invoke("ResetAttackCooldown", 1);
        }
    }

    private void ResetAttackCooldown()
    {
        canAttack = true;
    }
}
