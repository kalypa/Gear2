using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface StatEvent
{
    void Damaged(int hp, int damage); //������ �Ծ��� ��
    void Healed(int hp, int heal); //ü�� ȸ��
    void Dead(); //�׾��� ��

}
