using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GoldManager : MonoSingleton<GoldManager>
{
    public TextMeshProUGUI text;
    Money gold;
    private void Start()
    {
        gold = new Money();
        gold.EarnMoney(Money.ReturnMoney(0, 0));
        GoldText(gold);
    }

    void GoldText(Money money)
    {
        text.text = money.GetMoney();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gold.EarnMoney(Money.ReturnMoney(0, 10));
        }
        GoldText(gold);
    }
}
