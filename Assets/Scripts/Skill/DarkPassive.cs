using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkPassive : MonoBehaviour
{
    private float damageInterval = 0.5f; 
    private float timeSinceLastDamage = 0f;
    public PlayerTransform playerTransform;
    private void OnTriggerStay2D(Collider2D collision) // 다크 패시브 스킬 범위 내에 들어와있다면 
    {
        if(playerTransform.playermode == 2)
        {
            var gm = GameManager.Inst;
            if (collision.CompareTag("Monster") && !collision.GetComponent<MonsterAtk>().isDead)
            {
                timeSinceLastDamage += Time.deltaTime;

                if (timeSinceLastDamage >= damageInterval)
                {
                    collision.GetComponent<MonsterEvent>().Damaged(collision.GetComponent<MonsterEvent>().currenthp, gm.playerStat.darkPassiveAtk);
                    timeSinceLastDamage = 0f;
                }
            }
        }
    }
}
