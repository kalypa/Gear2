using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSkill : MainSkillManager
{
    [SerializeField] private Image skillFillAmount;
    [SerializeField] private TextMeshProUGUI skillCoolTimeText;
    [SerializeField] private Text scarceText;
    [SerializeField] private SkillStat[] skillStat = new SkillStat[3];

    public List<Animator> skillList = new();
    public GameObject[] skills = new GameObject[3];
    private PlayerEvent player;
    private PlayerTransform playerTrans;
    public bool isSkillAtk = false;
    private void Start()
    {
        player = GetComponent<PlayerEvent>();
        playerTrans = GetComponent<PlayerTransform>();
    }
    public void OnClickMainSkillbutton()
    {
        if(isUseSkill && IsInAttackRange(skillStat[playerTrans.playermode - 1].attackRadius))
        {
            MainSkill();
        }
    }
    void MainSkill()
    {
        if (playerTrans.playermode != 3) skillList[playerTrans.playermode - 1].transform.position = SkillIndex();
        else SkillAngle(skillStat[2].attackRadius);
        skillList[playerTrans.playermode - 1].SetTrigger("Skill");
        UseSkill(skillCoolTimeText, skillFillAmount, skillStat[playerTrans.playermode - 1]);
        player.UseMana(GameManager.Inst.playerStat.mp, skillStat[playerTrans.playermode - 1].costMana);
        SkillAtk();
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

    void SkillAngle(float radius)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Monster") && !collider.GetComponent<MonsterAtk>().isDead)
            {
                Vector3 direction = collider.transform.position - transform.position;

                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
               skillList[playerTrans.playermode - 1].transform.parent.eulerAngles = new Vector3(0, 0, angle);
            }
        }
    }

    void SkillAtk()
    {
        isSkillAtk = true;
        BoxCollider2D myCollider = skills[playerTrans.playermode - 1].GetComponent<BoxCollider2D>();

        Vector2 overlapBoxSize = myCollider.bounds.size;
        Collider2D[] colliders = Physics2D.OverlapBoxAll(skills[playerTrans.playermode - 1].transform.position, overlapBoxSize, 0f);

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Monster") && !collider.GetComponent<MonsterAtk>().isDead)
            {
                collider.GetComponent<MonsterEvent>().Damaged(collider.GetComponent<MonsterEvent>().currenthp, skillStat[playerTrans.playermode - 1].damage);
            }
        }
    }

}
