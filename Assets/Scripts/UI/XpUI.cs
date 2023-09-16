using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class XpUI : MonoBehaviour
{
    public Image xpBar;
    public TextMeshProUGUI percentText;
    public TextMeshProUGUI levelText;
    void Update() => SetXp();

    void SetXp()
    {
        var stat = GameManager.Inst.playerStat;
        Debug.Log(stat.xp / stat.maxXp);
        xpBar.fillAmount = stat.xp / stat.maxXp;
        levelText.text = stat.level.ToString();
        percentText.text = "(" + ((stat.xp / stat.maxXp) * 100).ToString("F2") + "%)";
    }
}
