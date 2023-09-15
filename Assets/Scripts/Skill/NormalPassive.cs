using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalPassive : MonoBehaviour
{
    public void Atk()
    {
        var gm = GameManager.Inst;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 4);

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Monster") && !collider.GetComponent<MonsterAtk>().isDead)
            {
                collider.GetComponent<MonsterEvent>().Damaged(collider.GetComponent<MonsterEvent>().currenthp, gm.playerStat.normalPassiveAtk);
            }
        }
    }
}
