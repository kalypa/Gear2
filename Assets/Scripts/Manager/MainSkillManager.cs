using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainSkillManager : MonoBehaviour
{
    public bool isUseSkill = true;
    public bool isUsed = true;
    public void UseSkill(TextMeshProUGUI skillCoolTimeText, Image skillFillAmount, SkillStat skillStat) //��ų ���
    {
        if (isUseSkill)
        {
            isUseSkill = false;
            skillCoolTimeText.text = "";
            skillFillAmount.fillAmount = 1;
            StartCoroutine(SkillCoroutine(skillCoolTimeText, skillFillAmount, skillStat));
        }
    }
    IEnumerator SkillCoroutine(TextMeshProUGUI skillCoolTimeText, Image skillFillAmount, SkillStat skillStat) //��ų ��Ÿ�� �̹��� Ȱ��ȭ
    {
        StartCoroutine(CoolTimeCountCoroutine(skillStat.coolTime, skillCoolTimeText, skillFillAmount));
        while (skillFillAmount.fillAmount > 0)
        {
            skillFillAmount.fillAmount -= 1 * Time.smoothDeltaTime / skillStat.coolTime;
            yield return null;
        }
    }
    IEnumerator CoolTimeCountCoroutine(float number, TextMeshProUGUI skillCoolTimeText, Image skillFillAmount) //��ų ��Ÿ�� �ؽ�Ʈ Ȱ��ȭ
    {
        if (number > 0)
        {
            number -= 1;

            skillCoolTimeText.text = number.ToString();

            yield return new WaitForSeconds(1f);
            StartCoroutine(CoolTimeCountCoroutine(number, skillCoolTimeText, skillFillAmount));
        }
        else
        {
            skillFillAmount.fillAmount = 0;
            skillCoolTimeText.text = "";
            isUsed = true;
            isUseSkill = true;
            yield break;
        };
    }
}
