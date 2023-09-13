using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GoldManager : MonoSingleton<GoldManager>
{
    public TextMeshProUGUI text;
    public Money gold;
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
        if (Input.GetKey(KeyCode.Space))
        {
            gold.EarnMoney(Money.ReturnMoney(0, 100));
        }
        GoldText(gold);
    }
}
