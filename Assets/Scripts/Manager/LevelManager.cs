using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Image levelUpButton;
    void Update() => CanLevelUp();

    public void OnClickLevelUp() //������ ��ư ������ ��
    {
        var stat = GameManager.Inst.playerStat;
        if (stat.xp >= stat.maxXp)
        {
            GameManager.Inst.playerStat.level += 1;
            stat.xp = 0;
            stat.maxXp += 100;
            stat.atk += 4;
            stat.hp += 40;
            stat.mp += 80;
        }
    }

    void CanLevelUp() //������ �������� üũ�ϰ� ��ư ���� ����
    {
        var stat = GameManager.Inst.playerStat;
        if (stat.xp > stat.maxXp)
        {
            levelUpButton.color = new Color(0.9339623f, 0.813764f, 0.3127893f);
        }
        else
        {
            levelUpButton.color = new Color(0.6320754f, 0.6320754f, 0.6320754f);
        }
    }
}
