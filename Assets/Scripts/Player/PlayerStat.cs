using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="SO/PlayerStat")]
public class PlayerStat : ScriptableObject
{
    public int level;
    public int atk;
    public int maxHp;
    public int hp;
    public float mp;
    public float maxMp;
    public int mpSpeed;
    public int maxXp;
    public int xp;
    public float atkSpeed;
}
