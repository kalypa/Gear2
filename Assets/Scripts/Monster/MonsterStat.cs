using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/MonsterStat")]
public class MonsterStat : ScriptableObject
{
    public int atk;
    public int hp;
    public int maxHp;
    public int gold;
    public int goldIndex;
    public int xp;
}
