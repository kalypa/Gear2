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
    public void OnClickMainSkillbutton() => SkillAction(); //메인 스킬 버튼 눌렀을 때 
    void UseSkillAuto() //자동 스킬 사용
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
    void SkillAction() //스킬 사용 조건에 맞는지 체크
    {
        if (isUseSkill && IsInAttackRange(skillStat[GameManager.Inst.playerTransform.playermode - 1].attackRadius))
        {
            if(skillStat[GameManager.Inst.playerTransform.playermode - 1].costMana <= GameManager.Inst.playerStat.mp && !GameManager.Inst.playerTransform.isTransform)
            {
                MainSkill();
            }
        }
    }

    void MainSkill() //스킬 사용
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
    void SkillSound() //스킬 사운드 재생
    {
        skillSounds[GameManager.Inst.playerTransform.playermode - 1].Play();
    }
    bool IsInAttackRange(float radius) //적이 스킬 범위 내에 있는지 체크
    {
        if (NearMonsterPosition(radius).x == transform.position.x && NearMonsterPosition(radius).y == transform.position.y) return false;
        return true;
    }

    Vector2 SkillIndex() => GameManager.Inst.playerTransform.playermode switch //적 위치 반환
    {
        1 => transform.position,
        2 => NearMonsterPosition(skillStat[1].attackRadius),
        3 => NearMonsterPosition(skillStat[2].attackRadius),
        _ => throw new System.NotImplementedException()
    };

    Vector2 NearMonsterPosition(float radius) //가까운 적 위치 찾기
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

    void SkillAngle(float radius) //스킬 각도 재기
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

    void SkillAtk() //스킬 발동 시 몬스터에게 데미지 주는 로직
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
