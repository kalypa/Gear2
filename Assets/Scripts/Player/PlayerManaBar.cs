using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManaBar : MonoBehaviour
{
    public Image manaImage;

    void Update() => HealMana();
    public void SetMana(float currentMana, float maxMana) //마나 UI 세팅
    {
        manaImage.fillAmount = currentMana / maxMana;
    }
    void HealMana() //초당 마나 회복
    {
        if (GameManager.Inst.playerStat.mp < GameManager.Inst.playerStat.maxMp)
            GameManager.Inst.playerStat.mp += GameManager.Inst.playerStat.mpSpeed * Time.deltaTime;
        SetMana(GameManager.Inst.playerStat.mp, GameManager.Inst.playerStat.maxMp);
    }
}
