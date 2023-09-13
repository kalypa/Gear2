using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTransform : MonoBehaviour
{
    [SerializeField] private Animator lightEffectAnimator;
    [SerializeField] private GameObject toDarkButton;
    [SerializeField] private GameObject toWhiteButton;
    [SerializeField] private GameObject darkToNormalButton;
    [SerializeField] private GameObject whiteToNormalButton;
    [SerializeField] private Image mainSkillIcon;

    private Animator animator;

    private int playermode = 1;

    public bool isTransform = false;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void OnClickTransformDarkButton()
    {
        if (playermode == 1)
        {
            ChangeForm("NormalToDark_Translate", "NormalToDark", toDarkButton, darkToNormalButton, 2);
        }
        else if (playermode == 3)
        {
            ChangeForm("WhiteToDark_Translate", "WhiteToDark", toDarkButton, darkToNormalButton, 2);
            whiteToNormalButton.SetActive(false);
            toWhiteButton.SetActive(true);
        }
    }

    public void OnClickTransformWhiteButton()
    {
        if (playermode == 1)
        {
            ChangeForm("NormalToWhite_Translate", "NormalToWhite", toWhiteButton, whiteToNormalButton, 3);
        }
        else if (playermode == 2) 
        {
            ChangeForm("DarkToWhite_Translate", "DarkToWhite", toWhiteButton, whiteToNormalButton, 3);
            darkToNormalButton.SetActive(false);
            toDarkButton.SetActive(true);
        }
    }

    public void OnClickTransformWhiteToNormalButton()
    {
        ChangeForm("WhiteToNormal_Translate", "WhiteToNormal", whiteToNormalButton, toWhiteButton, 1);
    }

    public void OnClickTransformDarkToNormalButton()
    {
        ChangeForm("DarkToNormal_Translate", "DarkToNormal", darkToNormalButton, toDarkButton, 1);
    }

    void ChangeForm(string animationName, string lightAnimationName, GameObject btn1, GameObject btn2, int index)
    {
        isTransform = true;
        animator.Play(animationName);
        lightEffectAnimator.Play(lightAnimationName);
        btn1.SetActive(false);
        btn2.SetActive(true);
        playermode = index;
        animator.SetInteger("PlayerMode", playermode);
        Invoke("TransformAtk", 2f);
    }

    void TransformAtk()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 3);

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Monster") && !collider.GetComponent<MonsterAtk>().isDead)
            {
                collider.GetComponent<MonsterEvent>().Damaged(collider.GetComponent<MonsterEvent>().currenthp, GameManager.Inst.playerStat.atk * 2);
            }
        }
    }
}
