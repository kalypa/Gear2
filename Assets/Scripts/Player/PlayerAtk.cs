using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtk : AtkModule<Animator>
{
    public Animator whiteEffect;
    public Animator normalEffect;
    int atkCount = 0;
    protected override void Start()
    {
        base.Start();
        attackRadius = 1f;
    }

    public void Attack()
    {
        if (isAtk && !isDead && !GameManager.Inst.playerTransform.isTransform && !GameManager.Inst.playerskill.isSkillAtk)
        {
            var gm = GameManager.Inst;
            var mode = GetComponent<PlayerTransform>().playermode;
            isAtk = false;
            animator.SetTrigger("IsAtk");
            PassiveAtk(mode);
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, attackRadius);

            foreach (Collider2D collider in colliders)
            {
                if (collider.CompareTag("Monster") && !collider.GetComponent<MonsterAtk>().isDead)
                {
                    collider.GetComponent<MonsterEvent>().Damaged(collider.GetComponent<MonsterEvent>().currenthp, gm.playerStat.atk);
                }
            }
            Invoke("ResetAttackCooldown", GameManager.Inst.playerStat.atkSpeed);
        }
    }
    void PassiveAtk(int mode)
    {
        if(mode == 1)
        {
            normalEffect.SetTrigger("Atk");
            normalEffect.GetComponent<NormalPassive>().Atk();
        }
        else if (mode == 3)
        {
            atkCount += 1;
            if (atkCount % 3 == 0)
            {
                whiteEffect.SetTrigger("Atk");
                whiteEffect.GetComponent<WhitePassive>().Move();
            }
        }
    }
    private void ResetAttackCooldown()
    {
        isAtk = true;
    }
}
