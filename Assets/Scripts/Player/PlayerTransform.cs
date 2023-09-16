using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTransform : SkillManager
{
    [SerializeField] private Animator lightEffectAnimator;
    [SerializeField] private GameObject toDarkButton;
    [SerializeField] private GameObject toWhiteButton;
    [SerializeField] private GameObject darkToNormalButton;
    [SerializeField] private GameObject whiteToNormalButton;
    [SerializeField] private Image mainSkillIcon;
    [SerializeField] private Sprite[] mainSkillSprite = new Sprite[3];

    [SerializeField] private Image[] skillFillAmounts = new Image[4];

    [SerializeField] private TextMeshProUGUI[] skillCoolTimeTexts = new TextMeshProUGUI[4];
    [SerializeField] private SkillStat[] skillStats = new SkillStat[4];
    private PlayerEvent player;
    private Animator animator;
    public int playermode = 1;
    public Animator darkEffect;
    public bool isTransform = false;
    public bool isAuto = false;
    public AudioSource transformSound;
    private void Start()
    {
        animator = GetComponent<Animator>();
        player = GetComponent<PlayerEvent>();
    }

    public void OnClickTransformDarkButton()
    {
        if(isUseSkill)
        {
            if (playermode == 1)
            {
                ChangeForm("NormalToDark_Translate", "NormalToDark", toDarkButton, darkToNormalButton, mainSkillSprite[1], 2, 2, 1);
            }
            else if (playermode == 3)
            {
                ChangeForm("WhiteToDark_Translate", "WhiteToDark", toDarkButton, darkToNormalButton, mainSkillSprite[1], 2, 2, 1);
                whiteToNormalButton.SetActive(false);
                toWhiteButton.SetActive(true);
            }
        }
    }
    private void Update()
    {
        AutoSkill();
    }
    void AutoSkill()
    {
        if(isAuto && isUseSkill)
        {
            if (isUsed)
            {
                if (playermode == 1)
                {
                    ChangeForm("NormalToDark_Translate", "NormalToDark", toDarkButton, darkToNormalButton, mainSkillSprite[1], 2, 2, 1);
                    isUsed = false;
                }
                else if (playermode == 2)
                {
                    ChangeForm("DarkToWhite_Translate", "DarkToWhite", toWhiteButton, whiteToNormalButton, mainSkillSprite[2], 3, 3, 0);
                    isUsed = false;
                    darkToNormalButton.SetActive(false);
                    toDarkButton.SetActive(true);
                }
                else if (playermode == 3)
                {
                    ChangeForm("WhiteToNormal_Translate", "WhiteToNormal", whiteToNormalButton, toWhiteButton, mainSkillSprite[0], 1, 1, 0);
                    isUsed = false;
                }
            }
        }
    }
    public void OnClickTransformWhiteButton()
    {
        if (isUseSkill)
        {
            if (playermode == 1)
            {
                ChangeForm("NormalToWhite_Translate", "NormalToWhite", toWhiteButton, whiteToNormalButton, mainSkillSprite[2], 3, 3, 0);
            }
            else if (playermode == 2)
            {
                ChangeForm("DarkToWhite_Translate", "DarkToWhite", toWhiteButton, whiteToNormalButton, mainSkillSprite[2], 3, 3, 0);
                darkToNormalButton.SetActive(false);
                toDarkButton.SetActive(true);
            }
        }
    }

    public void OnClickTransformWhiteToNormalButton()
    {
        if (isUseSkill)
        {
            ChangeForm("WhiteToNormal_Translate", "WhiteToNormal", whiteToNormalButton, toWhiteButton, mainSkillSprite[0], 1, 1, 0);
        }
    }

    public void OnClickTransformDarkToNormalButton()
    {
        if (isUseSkill)
        {
            ChangeForm("DarkToNormal_Translate", "DarkToNormal", darkToNormalButton, toDarkButton, mainSkillSprite[0], 1, 0, 1);
        }
    }

    void ChangeForm(string animationName, string lightAnimationName, GameObject btn1, GameObject btn2, Sprite mSkill, int index, int skillIndex1, int skillIndex2)
    {
        if (skillStats[index].costMana <= GameManager.Inst.playerStat.mp)
        {
            transformSound.Play();
            darkEffect.SetBool("Atk", false);
            player.UseMana(GameManager.Inst.playerStat.mp, skillStats[index].costMana);
            isTransform = true;
            animator.Play(animationName);
            lightEffectAnimator.Play(lightAnimationName);
            btn1.SetActive(false);
            btn2.SetActive(true);
            mainSkillIcon.sprite = mSkill;
            UseSkill(skillCoolTimeTexts[skillIndex1], skillFillAmounts[skillIndex1], skillCoolTimeTexts[skillIndex2], skillFillAmounts[skillIndex2], skillStats[index]);
            playermode = index;
            animator.SetInteger("PlayerMode", playermode);
            StartCoroutine(TransformAtk(index));
        }
    }
    IEnumerator TransformAtk(int index)
    {
        yield return new WaitForSeconds(2f);
        ShakeCamera.Inst.Shake();
        if (playermode == 2) darkEffect.SetBool("Atk", true);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, skillStats[index].attackRadius);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Monster") && !collider.GetComponent<MonsterAtk>().isDead)
            {
                collider.GetComponent<MonsterEvent>().Damaged(collider.GetComponent<MonsterEvent>().currenthp, skillStats[index].damage);
            }
        }
    }
}
