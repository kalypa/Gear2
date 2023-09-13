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
    private MeshRenderer meshRenderer;
    void Start()
    {
        animator = GetComponent<SkeletonAnimation>();
        currenthp = GameManager.Inst.monsterStats[GameManager.Inst.currentStage].hp;
        maxHp = GameManager.Inst.monsterStats[GameManager.Inst.currentStage].maxHp;
        move = GetComponent<MonsterMove>();
        atk = GetComponent<MonsterAtk>();
        meshRenderer = GetComponent<MeshRenderer>();
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
        if(!atk.isDead && !move.isDead)
        {
            atk.isDead = true;
            move.isDead = true;
            healthBar.gameObject.SetActive(false);
            animator.AnimationState.SetAnimation(0, "Dead", false);
            Invoke("DeadEffect", 1f);
        }
    }

    void DeadEffect()
    {
        meshRenderer.enabled = false;
        deadEffect.gameObject.SetActive(true);
        Invoke("ResetMonster", 1f);
    }
    void ResetMonster()
    {
        PoolManager.Instance.TakeToPool(GameManager.Inst.currentStage, this);
        GameManager.Inst.monsterCount -= 1;
    }
    public void OnCreatedInPool() { }

    public void OnGettingFromPool()
    {
        if(meshRenderer != null) meshRenderer.enabled = true;
        if(deadEffect != null) deadEffect.gameObject.SetActive(false);
        if(atk != null) atk.isDead = false;
        if(move != null) move.isDead = false;
        if(healthBar != null) healthBar.SetHealth(currenthp, maxHp);
    }
}
