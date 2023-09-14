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

    public List<GameObject> skillList = new();
    public GameObject[] skills = new GameObject[3];
    private PlayerEvent player;
    private PlayerTransform playerTrans;

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
        skillList[playerTrans.playermode - 1].transform.position = SkillIndex();
        skillList[playerTrans.playermode - 1].gameObject.SetActive(true);
        UseSkill(skillCoolTimeText, skillFillAmount, skillStat[playerTrans.playermode - 1]);
        player.UseMana(GameManager.Inst.playerStat.mp, skillStat[playerTrans.playermode - 1].costMana);
        StartCoroutine(SkillAtk());
        Invoke("EndAtk", 2f);
    }

    bool IsInAttackRange(float radius)
    {
        if (NearMonsterPosition(radius).x == transform.position.x && NearMonsterPosition(radius).y == transform.position.y) return false;
        return true;
    }

    void EndAtk()
    {
        skillList[playerTrans.playermode - 1].gameObject.SetActive(false);
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

    IEnumerator SkillAtk()
    {
        yield return new WaitForSeconds(1f);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(skills[playerTrans.playermode - 1].transform.position, skillStat[playerTrans.playermode - 1].attackRadius);

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Monster") && !collider.GetComponent<MonsterAtk>().isDead)
            {
                collider.GetComponent<MonsterEvent>().Damaged(collider.GetComponent<MonsterEvent>().currenthp, skillStat[playerTrans.playermode - 1].damage);
            }
        }
    }

}
