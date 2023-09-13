using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money
{
    double current;  // ���� ǥ���ؾ��ϴ� ��
    int index;
    int[] money; // �� 1.0A ~ 999Z ���� �����

    public Money()
    {
        money = new int[26];  // A~Z
    }

    static public Money ReturnMoney(int index, int amount)
	{
        Money money = new Money();
        money.index = index;
        money.money[index - 1] = amount;
        return money;
    }

    public void SetMoney(int[] money)
	{
        this.money = money;
	}

    public void EarnMoney(Money p_money)
    {   // �� ����
        for (int i = 0; i < p_money.index; i++)
        {
            money[i] += p_money.money[i];
        }
    }

    public void SpendMoney(Money p_money)
    {  // �� ����
        for (int i = 0; i < p_money.index; i++)
        {
            money[i] -= p_money.money[i];

        }
    }

    public double getmoney()
    {   // ���� �� ���� �޾ƿ���

        if (index > 0)
        {
            current = money[index] + (double)(money[index - 1] / 1000);
        }
        else
        {
            current = money[index];
        }
        return current;
    }

    public void update()
    { 
        // �������� ������ �� ���� ����
        for (int i = 0; i < 26; i++)
        {
            if (money[i] >= 1000)
            {
                money[i + 1] += money[i] / 1000;
                money[i] %= 1000;
            }
            else if(money[i] < 0 && money[i + 1] > 0)
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
    {  // ���ڿ��� ���׼� �޾ƿ���.
        update();
        string s = "";
        char unit;
        unit = (char)(65 + index);

        s = getmoney().ToString() + unit.ToString();
        return s;
    }
}
