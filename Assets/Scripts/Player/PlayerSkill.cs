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
    public GameObject[] skillAngle = new GameObject[3];
    private PlayerEvent player;
    public bool isSkillAtk = false;
    public bool isAuto = false;
    public AudioSource[] skillSounds = new AudioSource[3];
    private void Start()
    {
        player = GetComponent<PlayerEvent>();
    }
    private void Update() => UseSkillAuto();
    public void OnClickMainSkillbutton() => SkillAction(); //���� ��ų ��ư ������ �� 
    void UseSkillAuto() //�ڵ� ��ų ���
    {
        if(isAuto && isUseSkill && IsInAttackRange(skillStat[GameManager.Inst.playerTransform.playermode - 1].attackRadius))
        {
            if(!GameManager.Inst.playerTransform.isTransform)
            {
                if (isUsed)
                {
                    SkillAction();
                    
                }
            }
        }
    }
    void SkillAction() //��ų ��� ���ǿ� �´��� üũ
    {
        if (isUseSkill && IsInAttackRange(skillStat[GameManager.Inst.playerTransform.playermode - 1].attackRadius))
        {
            if(skillStat[GameManager.Inst.playerTransform.playermode - 1].costMana <= GameManager.Inst.playerStat.mp && !GameManager.Inst.playerTransform.isTransform)
            {
                MainSkill();
            }
        }
    }

    void MainSkill() //��ų ���
    {
        isUsed = false;
        ShakeCamera.Inst.Shake();
        SkillSound();
        if (GameManager.Inst.playerTransform.playermode != 3) skillList[GameManager.Inst.playerTransform.playermode - 1].transform.position = SkillIndex();
        else SkillAngle(skillStat[2].attackRadius);
        skillList[GameManager.Inst.playerTransform.playermode - 1].SetTrigger("Skill");
        UseSkill(skillCoolTimeText, skillFillAmount, skillStat[GameManager.Inst.playerTransform.playermode - 1]);
        player.UseMana(GameManager.Inst.playerStat.mp, skillStat[GameManager.Inst.playerTransform.playermode - 1].costMana);
        SkillAtk();
    }
    void SkillSound() //��ų ���� ���
    {
        skillSounds[GameManager.Inst.playerTransform.playermode - 1].Play();
    }
    bool IsInAttackRange(float radius) //���� ��ų ���� ���� �ִ��� üũ
    {
        if (NearMonsterPosition(radius).x == transform.position.x && NearMonsterPosition(radius).y == transform.position.y) return false;
        return true;
    }

    Vector2 SkillIndex() => GameManager.Inst.playerTransform.playermode switch //�� ��ġ ��ȯ
    {
        1 => transform.position,
        2 => NearMonsterPosition(skillStat[1].attackRadius),
        3 => NearMonsterPosition(skillStat[2].attackRadius),
        _ => throw new System.NotImplementedException()
    };

    Vector2 NearMonsterPosition(float radius) //����� �� ��ġ ã��
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

    void SkillAngle(float radius) //��ų ���� ���
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Monster") && !collider.GetComponent<MonsterAtk>().isDead)
            {
                Vector3 direction = collider.transform.position - transform.position;

                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
               skillList[GameManager.Inst.playerTransform.playermode - 1].transform.parent.eulerAngles = new Vector3(0, 0, angle);
            }
        }
    }

    void SkillAtk() //��ų �ߵ� �� ���Ϳ��� ������ �ִ� ����
    {
        isSkillAtk = true;
        BoxCollider2D myCollider = skills[GameManager.Inst.playerTransform.playermode - 1].GetComponent<BoxCollider2D>();

        Vector2 overlapBoxSize = myCollider.bounds.size;
        Collider2D[] colliders = Physics2D.OverlapBoxAll(skills[GameManager.Inst.playerTransform.playermode - 1].transform.position, overlapBoxSize, skillAngle[GameManager.Inst.playerTransform.playermode - 1].transform.eulerAngles.z);

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Monster") && !collider.GetComponent<MonsterAtk>().isDead)
            {
                collider.GetComponent<MonsterEvent>().Damaged(collider.GetComponent<MonsterEvent>().currenthp, skillStat[GameManager.Inst.playerTransform.playermode - 1].damage);
            }
        }
    }

}
