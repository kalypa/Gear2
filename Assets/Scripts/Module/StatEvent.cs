using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface StatEvent
{
    void Damaged(int hp, int damage); //데미지 입었을 때
    void Healed(int hp, int heal); //체력 회복
    void Dead(); //죽었을 때

}
