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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isAtk = true;
            StartCoroutine(Attack(collision));
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isAtk = false;
    }
    IEnumerator Attack(Collider2D collision)
    {
        while (true)
        {
            if(isAtk && !isDead)
            {
                var gm = GameManager.Inst;
                animator.AnimationState.SetAnimation(0, "Attack", false);
                collision.GetComponent<PlayerEvent>().Damaged(gm.playerStat.hp, gm.monsterStats[gm.currentStage].atk);
                yield return new WaitForSeconds(1f);
            }
            else
            {
                break;
            }
        }
    }
}
