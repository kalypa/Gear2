using Spine;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAtk : AtkModule<SkeletonAnimation>
{
    protected override void Start()
    {
        base.Start();
        attackRadius = 0.5f;
    }

    private void OnTriggerEnter2D(Collider2D collision) //플레이어가 범위내에 있을때 공격
    {
        if (collision.CompareTag("Player"))
        {
            isAtk = true;
            StartCoroutine(Attack(collision));
        }
    }
    private void OnTriggerExit2D(Collider2D collision) //범위 밖이라면 다시 추격
    {
        isAtk = false;
    }
    IEnumerator Attack(Collider2D collision) //몬스터 공격 
    {
        while (true)
        {
            if(isAtk && !isDead)
            {
                var gm = GameManager.Inst;
                animator.AnimationState.SetAnimation(0, "Attack", false);
                if(!GameManager.Inst.playerTransform.isTransform)
                {
                    collision.GetComponent<PlayerEvent>().Damaged(gm.playerStat.hp, gm.monsterStats[gm.currentStage].atk);
                }
                yield return new WaitForSeconds(1f);
            }
            else
            {
                break;
            }
        }
    }
}
