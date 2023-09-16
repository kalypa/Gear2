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

    public void Attack() //플레이어 공격
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
            Invoke("ResetAttackCooldown", gm.playerStat.atkSpeed - gm.playerStat.addAtkSpeed);
        }
    }
    void PassiveAtk(int mode) //플레이어 패시브 공격
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
    private void ResetAttackCooldown() //공격 쿨타임 초기화
    {
        isAtk = true;
    }
}
