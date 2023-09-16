using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;

public class StatLevelUp : MonoBehaviour
{
    public TextMeshProUGUI nextStat;
    public Text statLevel;
    public StatSO statSO;
    public Image maxImage;
    int stat;
    void Update()
    {
        AddStat();
    }

    public void OnClickStatLevelUpButton()
    {
        if(statSO.prize <= GoldManager.Inst.gold.getmoney())
        {
            if (statSO.index != 3)
            {
                StatLevel();
            }
            else
            {
                GameManager.Inst.playerStat.addAtkSpeed += statSO.addStatF;
            }
            GoldManager.Inst.gold.SpendMoney(Money.ReturnMoney(statSO.goldIndex, statSO.prize));
            statSO.level += 1;
        }
    }
    int Stats() => statSO.index switch
    {
        0 => GameManager.Inst.playerStat.atk,
        1 => GameManager.Inst.playerStat.maxHp,
        2 => (int)GameManager.Inst.playerStat.maxMp,
        3 => (int)((GameManager.Inst.playerStat.atkSpeed + GameManager.Inst.playerStat.addAtkSpeed) * 100),
        4 => GameManager.Inst.playerStat.mpSpeed,
        5 => GameManager.Inst.playerStat.hpSpeed,
        6 => GameManager.Inst.playerStat.healHp,
        7 => GameManager.Inst.playerStat.healMp,
        _ => throw new System.NotImplementedException(),
    };

    void StatLevel()
    {
        switch (statSO.index)
        { 
            case 0:
                GameManager.Inst.playerStat.atk += statSO.addStat;
                break;
            case 1:
                GameManager.Inst.playerStat.maxHp += statSO.addStat;
                break;
            case 2:
                GameManager.Inst.playerStat.maxMp += statSO.addStat;
                break;
            case 4:
                GameManager.Inst.playerStat.mpSpeed += statSO.addStat;
                break;
            case 5:
                GameManager.Inst.playerStat.hpSpeed += statSO.addStat;
                break;
            case 6:
                GameManager.Inst.playerStat.healHp += statSO.addStat;
                break;
            case 7:
                GameManager.Inst.playerStat.healMp += statSO.addStat;
                break;
        }

    }

    void AddStat()
    {
        if(statSO.index != 3) nextStat.text = (Stats() + statSO.addStat).ToString();
        else nextStat.text = (Stats() + (int)(statSO.addStatF * 100)).ToString() + "%";
        statSO.prize = statSO.level * statSO.prize;
        if (statSO.prize >= 1000) statSO.goldIndex += 1;
        statLevel.text = statSO.level.ToString();
        if(statSO.level == statSO.maxLevel) maxImage.gameObject.SetActive(true);
    }
}
