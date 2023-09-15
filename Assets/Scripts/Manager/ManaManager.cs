using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ManaManager : MonoBehaviour
{
    public Text[] scarceTexts = new Text[5];
    public TextMeshProUGUI[] coolTimeText = new TextMeshProUGUI[5];
    public Image[] skillFillAmounts = new Image[5];
    public SkillStat[] skillStats = new SkillStat[5];
    private void Update()
    {
        ScarceMana();
        MainScareMana();
    }
    void ScarceMana()
    {
        for(int i = 0; i < 4; i++)
        {
            if (skillStats[i].costMana > GameManager.Inst.playerStat.mp) 
            {
                skillFillAmounts[i].fillAmount = 1;
                scarceTexts[i].text = "마나 부족";
                coolTimeText[i].enabled = false;
            }
            else if(GameManager.Inst.playerskill.isUseSkill && GameManager.Inst.playerTransform.isUseSkill)
            {
                if(skillFillAmounts[i].fillAmount == 1) skillFillAmounts[i].fillAmount = 0;
                scarceTexts[i].text = "";
                coolTimeText[i].enabled = true;
            }
        }
    }

    void MainScareMana()
    {
        if (skillStats[4].costMana > GameManager.Inst.playerStat.mp)
        {
            skillFillAmounts[4].fillAmount = 1;
            scarceTexts[4].text = "마나 부족";
            coolTimeText[4].enabled = false;
        }
        else if (GameManager.Inst.playerskill.isUseSkill && GameManager.Inst.playerTransform.isUseSkill)
        {
            skillFillAmounts[4].fillAmount = 0;
            scarceTexts[4].text = "";
            coolTimeText[4].enabled = true;
        }
    }
}
