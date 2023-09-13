using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface StatEvent
{
    void Damaged(int hp, int damage);
    void Healed(int hp, int heal);
    void Dead();

}
