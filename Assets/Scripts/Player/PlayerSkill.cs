using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSkill : MainSkillManager
{
    [SerializeField] private Image skillFillAmount;
    [SerializeField] private TextMeshProUGUI skillCoolTimeText;
    [SerializeField] private Text scarceText;
    [SerializeField] private SkillStat[] skillStat = new SkillStat[3];

    public List<ParticleSystem> SkillList = new();
    private PlayerEvent player;
    private PlayerTransform playerTrans;

    private void Start()
    {
        player = GetComponent<PlayerEvent>();
        playerTrans = GetComponent<PlayerTransform>();
    }
    public void OnClickMainSkillbutton()
    {
        if(isUseSkill && playerTrans.isUseSkill && IsInAttackRange(skillStat[playerTrans.playermode - 1].attackRadius))
        {
            MainSkill();
        }
    }
    private void Update()
    {
        if(!IsInAttackRange(skillStat[playerTrans.playermode - 1].attackRadius))
        {
            skillFillAmount.fillAmount = 1;
            if(skillStat[playerTrans.playermode - 1].costMana > GameManager.Inst.playerStat.mp)
            {
                scarceText.text = "마나 부족";
            }
            scarceText.text = "대상 거리 밖";
            skillCoolTimeText.enabled = false;
        }
        else
        {
            skillFillAmount.fillAmount = 0;
            scarceText.text = "";
            skillCoolTimeText.enabled = true;
        }
    }
    void MainSkill()
    {
        SkillList[playerTrans.playermode - 1].transform.position = SkillIndex();
        SkillList[playerTrans.playermode - 1].gameObject.SetActive(true);
        UseSkill(skillCoolTimeText, skillFillAmount, skillStat[playerTrans.playermode - 1]);
        player.UseMana(GameManager.Inst.playerStat.mp, skillStat[playerTrans.playermode - 1].costMana);
    }

    bool IsInAttackRange(float radius)
    {
        if (NearMonsterPosition(radius).x == transform.position.x && NearMonsterPosition(radius).y == transform.position.y) return false;
        return true;
    }

    Vector2 SkillIndex() => playerTrans.playermode switch
    {
        1 => transform.position,
        2 => NearMonsterPosition(skillStat[1].attackRadius),
        3 => NearMonsterPosition(skillStat[2].attackRadius),
        _ => throw new System.NotImplementedException()
    };

    Vector2 NearMonsterPosition(float radius)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Monster") && !collider.GetComponent<MonsterAtk>().isDead)
            {
                return collider.transform.position;
            }
        }
        return transform.position;
    }

}
