using Redcode.Pools;
using Spine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvent : MonoBehaviour, StatEvent
{
    public ParticleSystem deadEffect;
    public PlayerHealthBar healthBar;
    public int currenthp;
    public int maxHp;
    private void Start()
    {
        maxHp = GameManager.Inst.playerStat.maxHp;
        GameManager.Inst.playerStat.hp = maxHp;
        healthBar.SetHealth(maxHp, maxHp);
    }
    public void Damaged(int hp, int damage)
    {
        GameManager.Inst.playerStat.hp = hp - damage;
        healthBar.SetHealth(GameManager.Inst.playerStat.hp, maxHp);
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
