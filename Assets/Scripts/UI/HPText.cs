using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HPText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI hpText;
    void Update()
    {
        hpText.text = GameManager.Inst.playerStat.hp.ToString();
    }
}
