using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManaBar : MonoBehaviour
{
    public Image manaImage;

    void Update() => HealMana();
    public void SetMana(float currentMana, float maxMana) //���� UI ����
    {
        manaImage.fillAmount = currentMana / maxMana;
    }
    void HealMana() //�ʴ� ���� ȸ��
    {
        if (GameManager.Inst.playerStat.mp < GameManager.Inst.playerStat.maxMp)
            GameManager.Inst.playerStat.mp += GameManager.Inst.playerStat.mpSpeed * Time.deltaTime;
        SetMana(GameManager.Inst.playerStat.mp, GameManager.Inst.playerStat.maxMp);
    }
}
