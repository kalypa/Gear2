using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public Image healthImage;

    private void Start() => StartCoroutine(HpHealedPerSecond());
    IEnumerator HpHealedPerSecond() //�ʴ� HP ȸ��
    {
        while (true)
        {
            yield return new WaitForSeconds(1f); // 1�� ���

            if (GameManager.Inst.playerStat.hp < GameManager.Inst.playerStat.maxHp)
            {
                GameManager.Inst.playerStat.hp += GameManager.Inst.playerStat.hpSpeed;

                // ���� ü���� �ִ� ü���� �ʰ����� �ʵ��� ó��
                if (GameManager.Inst.playerStat.hp > GameManager.Inst.playerStat.maxHp)
                {
                    GameManager.Inst.playerStat.hp = GameManager.Inst.playerStat.maxHp;
                }
            }
        }
    }
    public void SetHealth(float currentHealth, float maxHealth) //HP �ؽ�Ʈ ���� 
    {
        healthImage.fillAmount = currentHealth / maxHealth;
    }
}
