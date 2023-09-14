using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ManaManager : MonoBehaviour
{
    public Text[] scarceTexts = new Text[4];
    public TextMeshProUGUI[] coolTimeText = new TextMeshProUGUI[4];
    public Image[] skillFillAmounts = new Image[4];
    public SkillStat[] skillStats = new SkillStat[4];
    private void Update()
    {
        ScarceMana();
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
            else
            {
                skillFillAmounts[i].fillAmount = 0;
                scarceTexts[i].text = "";
                coolTimeText[i].enabled = true;
            }
        }
    }
}
