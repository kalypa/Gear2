using Michsky.LSS;
using Redcode.Pools;
using Spine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvent : MonoBehaviour, StatEvent
{
    public PlayerHealthBar healthBar;
    public PlayerManaBar manaBar;
    public LSS_Manager lssManager;
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
    public void Damaged(int hp, int damage) //몬스터에게 데미지를 받았을 때
    {
        GameManager.Inst.playerStat.hp = hp - damage;
        healthBar.SetHealth(GameManager.Inst.playerStat.hp, maxHp);
        ShowDamageText(damage);
        if (hp <= 0) Dead();
    }
    public void UseMana(float mana, float used) //마나를 사용했을 때
    {
        GameManager.Inst.playerStat.mp = mana - used;
        manaBar.SetMana(GameManager.Inst.playerStat.mp, maxMp);
    }
    void ShowDamageText(int damage) //데미지 텍스트 보여주기
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 spawnPos = screenPos + new Vector3(0, 80f, 0);
        var damageTextObject = PoolManager.Instance.GetFromPool<DamageText>(4);
        damageTextObject.transform.position = spawnPos;
        damageTextObject.SetText(damage.ToString());
    }
    public void Healed(int hp, int heal) { } //회복
    public void Dead() //죽었을 때
    {
        lssManager.LoadScene("Stage" + (GameManager.Inst.currentStage + 1).ToString());
    }

}
