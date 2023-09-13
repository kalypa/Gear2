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
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void OnClickTransformDarkButton()
    {
        if (playermode == 1)
        {
            ChangeForm("NormalToDark_Translate", "NormalToDark", toDarkButton, darkToNormalButton);
        }
        else if (playermode == 3)
        {
            ChangeForm("WhiteToDark_Translate", "WhiteToDark", toDarkButton, darkToNormalButton);
            whiteToNormalButton.SetActive(false);
        }
        playermode = 2;
        animator.SetInteger("PlayerMode", playermode);
    }

    public void OnClickTransformWhiteButton()
    {
        if (playermode == 1)
        {
            ChangeForm("NormalToWhite_Translate", "NormalToWhite", toWhiteButton, whiteToNormalButton);
        }
        else if (playermode == 2) 
        {
            ChangeForm("DarkToWhite_Translate", "DarkToWhite", toWhiteButton, whiteToNormalButton);
            darkToNormalButton.SetActive(false);
        }
    }

    void ChangeForm(string animationName, string lightAnimationName, GameObject btn1, GameObject btn2)
    {
        animator.Play(animationName);
        lightEffectAnimator.Play(lightAnimationName);
        btn1.SetActive(false);
        btn2.SetActive(true);
    }
}
