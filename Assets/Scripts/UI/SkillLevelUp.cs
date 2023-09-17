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
    private int divideNum = 0;

    void Update() => SetSkillStat();
    public void OnClickSkillLevelUpButton() //��ų ������ ��ư ������ ��
    {
        if (GoldManager.Inst.gold.Index > 0)
        {
            if (skill.prize / divideNum <= GoldManager.Inst.gold.getmoney())
            {
                SpendGold();
            }
        }
        else
        {
            if (skill.prize <= GoldManager.Inst.gold.getmoney())
            {
                SpendGold();
            }
        }
    }
    void SpendGold()
    {
        if (skill.prize % 1000 == 0) skill.goldIndex += 1;
        skill.damage += skill.addDamage;
        if (skill.goldIndex > 0) GoldManager.Inst.gold.SpendMoney(Money.ReturnMoney(skill.goldIndex, skill.prize / divideNum));
        else GoldManager.Inst.gold.SpendMoney(Money.ReturnMoney(skill.goldIndex, skill.prize));
        skill.level += 1;
    }
    void SetSkillStat() //��ų ���� ����
    {
        divideNum = GoldManager.Inst.gold.Index * 1000;
        skill.prize = skill.level * 100;
        goldText.text = skill.prize.ToString();
        skillLevel.text = skill.level.ToString();
        if (skill.level == skill.maxLevel) maxImage.gameObject.SetActive(true);
    }
}
