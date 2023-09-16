using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HPText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI hpText;
    void Update() => SetHpText();

    void SetHpText() //ü�� �ؽ�Ʈ ����
    {
        hpText.text = GameManager.Inst.playerStat.hp.ToString();
    }
}
