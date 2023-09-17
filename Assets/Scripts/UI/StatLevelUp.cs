using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;

public class StatLevelUp : MonoBehaviour
{
    public TextMeshProUGUI nextStat;
    public TextMeshProUGUI goldText;
    public Text statLevel;
    public StatSO statSO;
    public Image maxImage;
    private int divideNum = 0;

    void Update() => AddStat();

    public void OnClickStatLevelUpButton() //스탯 레벨업 버튼 클릭
    {
        if(GoldManager.Inst.gold.Index > 0)
        {
            if (statSO.prize / divideNum <= GoldManager.Inst.gold.getmoney())
            {
                SpendGold();
            }
        }
        else
        {
            if (statSO.prize <= GoldManager.Inst.gold.getmoney())
            {
                SpendGold();
            }
        }
    }

    void SpendGold()
    {
        if (statSO.prize % 1000 == 0) statSO.goldIndex += 1;
        if (statSO.index != 3)
        {
            StatLevel();
        }
        else
        {
            GameManager.Inst.playerStat.addAtkSpeed += statSO.addStatF;
        }
        if (statSO.goldIndex > 0) GoldManager.Inst.gold.SpendMoney(Money.ReturnMoney(statSO.goldIndex, statSO.prize / divideNum));
        else GoldManager.Inst.gold.SpendMoney(Money.ReturnMoney(GoldManager.Inst.gold.Index, statSO.prize));
        statSO.level += 1;
    }
    int Stats() => statSO.index switch //증가시킬 스탯 판별
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

    void StatLevel() //스탯 조건에 따라 증가
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

    void AddStat() //스탯 증가
    {
        divideNum = GoldManager.Inst.gold.Index * 1000;
        if (statSO.index != 3) nextStat.text = (Stats() + statSO.addStat).ToString();
        else nextStat.text = (Stats() + (int)(statSO.addStatF * 100)).ToString() + "%";
        statSO.prize = statSO.level * 10;
        statLevel.text = statSO.level.ToString();
        if(statSO.level == statSO.maxLevel) maxImage.gameObject.SetActive(true);
        goldText.text = statSO.prize.ToString();
    }
}
