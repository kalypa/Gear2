using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public Image healthImage;

    private void Start() => StartCoroutine(HpHealedPerSecond());
    IEnumerator HpHealedPerSecond() //초당 HP 회복
    {
        while (true)
        {
            yield return new WaitForSeconds(1f); // 1초 대기

            if (GameManager.Inst.playerStat.hp < GameManager.Inst.playerStat.maxHp)
            {
                GameManager.Inst.playerStat.hp += GameManager.Inst.playerStat.hpSpeed;

                // 만약 체력이 최대 체력을 초과하지 않도록 처리
                if (GameManager.Inst.playerStat.hp > GameManager.Inst.playerStat.maxHp)
                {
                    GameManager.Inst.playerStat.hp = GameManager.Inst.playerStat.maxHp;
                }
            }
        }
    }
    public void SetHealth(float currentHealth, float maxHealth) //HP 텍스트 세팅 
    {
        healthImage.fillAmount = currentHealth / maxHealth;
    }
}
