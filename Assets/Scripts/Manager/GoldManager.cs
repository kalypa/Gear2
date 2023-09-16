using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class GoldManager : MonoSingleton<GoldManager>
{
    public GameObject goldText;
    public TextMeshProUGUI text;
    public Money gold;
    private void Awake() => DontDestroyOnLoad(gameObject);
    private void Start()
    {
        gold = new Money();
        gold.EarnMoney(Money.ReturnMoney(0, 0));
        GoldText(gold);
    }

    void GoldText(Money money) //골드 텍스트 설정
    {
        text.text = money.GetMoney();
    }

    private void Update() => SettingGold();

    void SettingGold() //골드 세팅
    {
        if (goldText == null) goldText = GameObject.Find("GoldAmountText");
        if (text == null) text = goldText.GetComponent<TextMeshProUGUI>();
        GoldText(gold);
    }
}
