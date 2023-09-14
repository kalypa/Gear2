using Redcode.Pools;
using Spine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvent : MonoBehaviour, StatEvent
{
    public ParticleSystem deadEffect;
    public PlayerHealthBar healthBar;
    public PlayerManaBar manaBar;
    public int currenthp;
    public int maxHp;
    public float maxMp;
    private void Start()
    {
        maxHp = GameManager.Inst.playerStat.maxHp;
        maxMp = GameManager.Inst.playerStat.maxMp;
        GameManager.Inst.playerStat.hp = maxHp;
        GameManager.Inst.playerStat.mp = maxMp;
        healthBar.SetHealth(maxHp, maxHp);
    }
    public void Damaged(int hp, int damage)
    {
        GameManager.Inst.playerStat.hp = hp - damage;
        healthBar.SetHealth(GameManager.Inst.playerStat.hp, maxHp);
        ShowDamageText(damage);
        if (hp <= 0) Dead();
    }
    public void UseMana(float mana, float used)
    {
        GameManager.Inst.playerStat.mp = mana - used;
        manaBar.SetMana(GameManager.Inst.playerStat.mp, maxMp);
    }
    void ShowDamageText(int damage)
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 spawnPos = screenPos + new Vector3(0, 80f, 0);
        var damageTextObject = PoolManager.Instance.GetFromPool<DamageText>(3);
        damageTextObject.GetComponent<RectTransform>().anchoredPosition = spawnPos;
        damageTextObject.SetText(damage.ToString());
    }
    public void Healed(int hp, int heal) { }
    public void Dead()
    {
        //Invoke("DeadEffect", 1f);
    }

}
