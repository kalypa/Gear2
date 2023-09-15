using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public int currentStage = 0;
    public int monsterCount;
    public PlayerStat playerStat;
    public MonsterStat[] monsterStats;
    public MonsterStat bossStats;
    public PlayerTransform playerTransform;
    public PlayerMove playermove;
    public PlayerSkill playerskill;
}
