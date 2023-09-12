using Redcode.Pools;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterEvent : MonoBehaviour, StatEvent, IPoolObject
{
    public ParticleSystem deadEffect;
    private SkeletonAnimation animator;
    void Start()
    {
        animator = GetComponent<SkeletonAnimation>();
    }

    public void Damaged(int hp, int damage)
    {
        hp = hp - damage;
        if (hp <= 0) Dead();
    }
    public void Healed(int hp, int heal) { }
    public void Dead()
    {
        animator.AnimationState.SetAnimation(0, "Dead", false);
        Invoke("DeadEffect", 1f);
    }

    void DeadEffect()
    {
        deadEffect.gameObject.SetActive(true);
        if(!deadEffect.isPlaying)
        {
            PoolManager.Instance.TakeToPool<MonsterEvent>(name, this);
            GameManager.Inst.monsterCount -= 1;
        }
    }

    public void OnCreatedInPool() { }

    public void OnGettingFromPool()
    {
        //deadEffect.gameObject.SetActive(false);
    }
}
