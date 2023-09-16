using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillLevelUp : MonoBehaviour
{
    public SkillStat skill;
    public TextMeshProUGUI goldText;
    public Text skillLevel;
    public Image maxImage;
    void Update() => SetSkillStat();
    public void OnClickSkillLevelUpButton()
    {
        if (skill.prize <= GoldManager.Inst.gold.getmoney())
        {
            skill.damage += skill.addDamage;
            GoldManager.Inst.gold.SpendMoney(Money.ReturnMoney(skill.goldIndex, skill.prize * skill.level));
            skill.level += 1;
        }
    }
    void SetSkillStat()
    {
        //if (skill.prize >= 1000) skill.goldIndex += 1;
        skill.prize = skill.level * skill.prize;
        goldText.text = (skill.prize * skill.level).ToString();
        skillLevel.text = skill.level.ToString();
        if (skill.level == skill.maxLevel) maxImage.gameObject.SetActive(true);
    }
}
