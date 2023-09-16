using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HPText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI hpText;
    void Update() => SetHpText();

    void SetHpText() //체력 텍스트 세팅
    {
        hpText.text = GameManager.Inst.playerStat.hp.ToString();
    }
}
