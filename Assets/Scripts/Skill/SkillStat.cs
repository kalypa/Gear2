using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Skill")]
public class SkillStat : ScriptableObject
{
    public int level;
    public int maxLevel;
    public int costMana;
    public float coolTime;
    public int damage;
    public float attackRadius;
    public int prize;
}
