using Redcode.Pools;
using Spine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvent : MonoBehaviour, StatEvent
{
    public ParticleSystem deadEffect;
    public void Damaged(int hp, int damage)
    {
        hp = hp - damage;
        if (hp <= 0) Dead();
    }
    public void Healed(int hp, int heal) { }
    public void Dead()
    {
        //Invoke("DeadEffect", 1f);
    }

    void DeadEffect()
    {
        deadEffect.gameObject.SetActive(true);
        if (!deadEffect.isPlaying)
        {
            PoolManager.Instance.TakeToPool<MonsterEvent>(name, this);
            GameManager.Inst.monsterCount -= 1;
        }
    }
}
