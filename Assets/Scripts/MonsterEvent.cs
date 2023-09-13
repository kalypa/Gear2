using Redcode.Pools;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class MonsterEvent : MonoBehaviour, StatEvent, IPoolObject
{
    public ParticleSystem deadEffect;
    private SkeletonAnimation animator;
    public int currenthp;
    public int maxHp;
    public MonsterHealthBar healthBar;
    private MonsterMove move;
    private MonsterAtk atk;
    void Start()
    {
        animator = GetComponent<SkeletonAnimation>();
        currenthp = GameManager.Inst.monsterStats[GameManager.Inst.currentStage].hp;
        maxHp = GameManager.Inst.monsterStats[GameManager.Inst.currentStage].maxHp;
        move = GetComponent<MonsterMove>();
        atk = GetComponent<MonsterAtk>();
        healthBar.SetHealth(currenthp, maxHp);
    }

    public void Damaged(int hp, int damage)
    {
        currenthp = hp - damage;
        if (!healthBar.gameObject.activeSelf) healthBar.gameObject.SetActive(true);
        healthBar.SetHealth(currenthp, maxHp);
        if (currenthp <= 0) Dead();
    }
    public void Healed(int hp, int heal) { }
    public void Dead()
    {
        atk.isDead = true;
        move.isDead = true;
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
