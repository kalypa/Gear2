using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour
{
    public bool isUseSkill = true;
    public void UseSkill(TextMeshProUGUI skillCoolTimeText, Image skillFillAmount, TextMeshProUGUI skillCoolTimeText2, Image skillFillAmount2, SkillStat skillStat)
    {
        if (isUseSkill)
        {
            isUseSkill = false;
            skillCoolTimeText.text = "";
            skillCoolTimeText2.text = "";
            skillFillAmount.fillAmount = 1;
            skillFillAmount2.fillAmount = 1;

            StartCoroutine(SkillCoroutine(skillCoolTimeText, skillFillAmount, skillCoolTimeText2, skillFillAmount2, skillStat));
        }
    }
    IEnumerator SkillCoroutine(TextMeshProUGUI skillCoolTimeText, Image skillFillAmount, TextMeshProUGUI skillCoolTimeText2, Image skillFillAmount2, SkillStat skillStat)
    {
        StartCoroutine(CoolTimeCountCoroutine(skillStat.coolTime, skillCoolTimeText, skillFillAmount, skillCoolTimeText2, skillFillAmount2));
        while (skillFillAmount.fillAmount > 0 && skillFillAmount2.fillAmount > 0)
        {
            skillFillAmount.fillAmount -= 1 * Time.smoothDeltaTime / skillStat.coolTime;
            skillFillAmount2.fillAmount -= 1 * Time.smoothDeltaTime / skillStat.coolTime;
            yield return null;
        }
    }
    IEnumerator CoolTimeCountCoroutine(float number, TextMeshProUGUI skillCoolTimeText, Image skillFillAmount, TextMeshProUGUI skillCoolTimeText2, Image skillFillAmount2)
    {
        if (number > 0)
        {
            number -= 1;

            skillCoolTimeText.text = number.ToString();
            skillCoolTimeText2.text = number.ToString();

            yield return new WaitForSeconds(1f);
            StartCoroutine(CoolTimeCountCoroutine(number, skillCoolTimeText, skillFillAmount, skillCoolTimeText2, skillFillAmount2));
        }
        else
        {
            skillFillAmount.fillAmount = 0;
            skillFillAmount2.fillAmount = 0;
            skillCoolTimeText.text = "";
            skillCoolTimeText2.text = "";
            isUseSkill = true;
            yield break;
        }
    }
}