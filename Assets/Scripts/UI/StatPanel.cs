using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatPanel : MonoBehaviour
{
    public TextMeshProUGUI[] statTexts = new TextMeshProUGUI[9]; //���� �ؽ�Ʈ��
    public int index;
    PlayerStat stat;
    RectTransform rect;
    public float startX;
    public float endX;
    private void Start()
    {
        stat = GameManager.Inst.playerStat;
        rect = GetComponent<RectTransform>();
    }
    void Update() => SetStatText();

    void SetStatText() //���� �ؽ�Ʈ ����
    {
        for(index = 0; index < statTexts.Length; index++) 
        {
            statTexts[index].text = StatText();
        }
    }

    string StatText() => index switch //�ε����� ���� ���ȼ���
    {
        0 => stat.atk.ToString(),
        1 => stat.maxHp.ToString(),
        2 => stat.maxMp.ToString(),
        3 => ((stat.atkSpeed + stat.addAtkSpeed) * 100).ToString() +"%",
        4 => stat.mpSpeed.ToString(),
        5 => stat.hpSpeed.ToString(),
        6 => stat.healHp.ToString(),
        7 => stat.healMp.ToString(),
        8 => "Level " + stat.level.ToString(),
        _ => throw new System.NotImplementedException(),
    };
    public void OnClickPanelEnterButton() //�г� ���̱�
    {
        rect.DOAnchorPosX(endX, 0.1f);
    }
    public void OnClickPanelExitButton() //�г� �����
    {
        rect.DOAnchorPosX(startX, 0.1f);
    }
}
