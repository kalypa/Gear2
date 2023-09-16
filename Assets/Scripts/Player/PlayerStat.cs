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
    public int hpSpeed;
    public float mp;
    public float maxMp;
    public int mpSpeed;
    public float maxXp;
    public float xp;
    public float atkSpeed;
    public float addAtkSpeed;
    public int healHp;
    public int healMp;
    public int whitePassiveAtk;
    public int darkPassiveAtk;
    public int normalPassiveAtk;
}
