using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtk : AtkModule<Animator>
{

    protected override void Start()
    {
        base.Start();
        attackRadius = 1f;
    }

    public void Attack()
    {
        if (isAtk && !isDead)
        {
            var gm = GameManager.Inst;
            isAtk = false;
            animator.SetTrigger("IsAtk");
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, attackRadius);

            foreach (Collider2D collider in colliders)
            {
                if (collider.CompareTag("Monster")) collider.GetComponent<MonsterEvent>().Damaged(collider.GetComponent<MonsterEvent>().currenthp, gm.playerStat.atk);
            }
            Invoke("ResetAttackCooldown", GameManager.Inst.playerStat.atkSpeed);
        }
    }

    private void ResetAttackCooldown()
    {
        isAtk = true;
    }
}
