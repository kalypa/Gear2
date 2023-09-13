using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GoldManager : MonoBehaviour
{
    public TextMeshProUGUI text;
    Money gold;
    private void Start()
    {
        gold.EarnMoney(Money.ReturnMoney(1, 0));
        GoldText();
    }

    void GoldText(Money money)
    {
        text.text = money.GetMoney();
    }
}
