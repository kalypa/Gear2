using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money
{
    public int Index
    {
        get
        {
            update();
            return index;
        }
    }
    char[] unit = new char[5];
    double current;  // 현재 표시해야하는 돈
    int index;
    int[] money; // 돈 1.0A ~ 999Z 까지 만들기

    public Money()
    {
        money = new int[26];  // A~Z
    }

    static public Money ReturnMoney(int index, int amount)
    {
        Money money = new Money();
        money.index = index;
        money.money[index] = amount;
        return money;
    }

    public void SetMoney(int[] money)
    {
        this.money = money;
    }

    public void EarnMoney(Money p_money)
    {   // 돈 벌기
        for (int i = 0; i <= p_money.index; i++)
        {
            money[i] += p_money.money[i];
        }
    }

    public void SpendMoney(Money p_money)
    {  // 돈 쓰기
        for (int i = 0; i <= p_money.index; i++)
        {
            money[i] -= p_money.money[i];

        }
    }

    public double getmoney()
    {   // 현재 돈 정보 받아오기
        if (index > 0)
        {
            current = money[index] + ((double)money[index - 1] / 1000);
            Debug.Log(current);
        }
        else
        {
            current = money[index];
        }
        return current;
    }

    public void update()
    {
        // 돈벌었기 했을떄 돈 단위 정리
        for (int i = 0; i < 26; i++)
        {
            if (money[i] >= 1000)
            {
                money[i + 1] += money[i] / 1000;
                money[i] %= 1000;
            }
            else if (money[i] < 0 && money[i + 1] > 0)
            {
                --money[i + 1];
                money[i] += 1000;
            }
        }
        for (int i = 0; i < 26; i++)
        {
            if (money[i] > 0)
            {
                index = i;
            }
        }
        if (index > 0)
        {
            current = money[index] + (double)(money[index - 1] / 1000);
        }
        else
        {
            current = money[index];
        }
    }

    public string GetMoney()
    {  // 문자열로 돈액수 받아오기.
        InitUnit();
        update();
        string s = "";
        if (index != 0) s = getmoney().ToString("F3") + unit[index - 1].ToString();
        else s = getmoney().ToString();
        return s;
    }

    void InitUnit()
    {
        unit[0] = 'K';
        unit[1] = 'M';
        unit[2] = 'B';
        unit[3] = 'T';
    }
}
