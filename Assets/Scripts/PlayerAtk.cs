using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtk : MonoBehaviour
{
    public float attackRadius = 3f;

    private bool canAttack = true;
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Attack()
    {
        if (canAttack)
        {
            var gm = GameManager.Inst;
            canAttack = false;
            animator.SetTrigger("IsAtk");
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, attackRadius);

            foreach (Collider2D collider in colliders)
            {
                if (collider.CompareTag("Monster")) collider.GetComponent<MonsterEvent>().Damaged(gm.monsterStats[gm.currentStage].hp, gm.playerStat.atk);
            }
            Invoke("ResetAttackCooldown", GameManager.Inst.playerStat.atkSpeed);
        }
    }

    private void ResetAttackCooldown()
    {
        canAttack = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
