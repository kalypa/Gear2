using Redcode.Pools;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MonsterEvent : MonoBehaviour, StatEvent, IPoolObject
{
    public Animator damageEffect;
    public Animator deadEffect;
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

    public void Damaged(int hp, int damage) //몬스터 데미지 입었을 때
    {
        currenthp = hp - damage;
        if (!healthBar.gameObject.activeSelf) healthBar.gameObject.SetActive(true);
        healthBar.SetHealth(currenthp, maxHp);
        ShowDamageText(damage);
        damageEffect.SetTrigger("Damaged");
        if (currenthp <= 0) Dead();
    }

    void ShowDamageText(int damage) //데미지 텍스트 출력
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 spawnPos = screenPos + new Vector3(0, 100f, 0);
        var damageTextObject = PoolManager.Instance.GetFromPool<DamageText>(3);
        damageTextObject.transform.position = spawnPos;
        damageTextObject.SetText(damage.ToString());
    }
    public void Healed(int hp, int heal) { } //회복(몬스터는 없음)
    public void Dead() //죽었을 때
    {
        if(!atk.isDead && !move.isDead)
        {
            var inst = GameManager.Inst;
            GoldManager.Inst.gold.EarnMoney(Money.ReturnMoney(inst.monsterStats[inst.currentStage].goldIndex, inst.monsterStats[inst.currentStage].gold));
            atk.isDead = true;
            move.isDead = true;
            healthBar.gameObject.SetActive(false);
            animator.AnimationState.SetAnimation(0, "Dead", false);
            inst.playermove.isAtk = false;
            inst.playerStat.xp += inst.monsterStats[inst.currentStage].xp;
            inst.playerStat.hp += inst.playerStat.healHp;
            if(inst.playerStat.hp > inst.playerStat.maxHp) inst.playerStat.hp = inst.playerStat.maxHp;
            inst.playerStat.mp += inst.playerStat.healMp;
            if (inst.playerStat.mp > inst.playerStat.maxMp) inst.playerStat.mp = inst.playerStat.maxMp;
            Invoke("DeadEffect", 1f);
        }
    }

    void DeadEffect() //죽음 이펙트
    {
        meshRenderer.enabled = false;
        deadEffect.SetTrigger("Dead");
        Invoke("ResetMonster", 1f);
    }
    void ResetMonster() //몬스터 초기화
    {
        PoolManager.Instance.TakeToPool(GameManager.Inst.currentStage, this);
        GameManager.Inst.monsterCount -= 1;
    }
    public void OnCreatedInPool() { }

    public void OnGettingFromPool() //풀매니저에서 꺼내올 때 초기화작업
    {
        if(meshRenderer != null) meshRenderer.enabled = true;
        if(atk != null) atk.isDead = false;
        if(move != null) move.isDead = false;
        if (GameManager.Inst.monsterStats[GameManager.Inst.currentStage] != null)
            currenthp = GameManager.Inst.monsterStats[GameManager.Inst.currentStage].maxHp;
        if(animator != null) animator.AnimationState.SetAnimation(0, "Walk", true);
        if (healthBar != null) healthBar.SetHealth(currenthp, maxHp);
    }
}
