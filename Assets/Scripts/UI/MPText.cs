using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MPText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI mpText;
    void Update()
    {
        mpText.text = ((int)GameManager.Inst.playerStat.mp).ToString();
    }
}
