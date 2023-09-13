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
    private void Update()
    {
        GoldText();
    }

    void GoldText()
    {
        text.text = gold.GetMoney();
    }
}
