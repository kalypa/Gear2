using Redcode.Pools;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> monsters = new();
    public List<Transform> spawnPos = new();

    bool isFirstSpawn = true;
    void Start()
    {
        StartSpawn();
        StartCoroutine(SpawnMonster(GameManager.Inst.currentStage));
    }

    void StartSpawn() //몬스터 생성 20번 반복
    {
        for(int i = 0; i < spawnPos.Count; i++)
        {
            var monster = PoolManager.Instance.GetFromPool<MonsterEvent>(GameManager.Inst.currentStage);
            monster.gameObject.transform.position = spawnPos[i].position;
            GameManager.Inst.monsterCount += 1;
        }
        isFirstSpawn = false;
    }

    IEnumerator SpawnMonster(int idx) //몬스터를 랜덤한 위치에 생성
    {
        while (true)
        {
            if(!isFirstSpawn)
            {
                if (GameManager.Inst.monsterCount < spawnPos.Count)
                {
                    int randomPosIdx = Random.Range(0, spawnPos.Count);
                    var monster = PoolManager.Instance.GetFromPool<MonsterEvent>(idx);
                    monster.gameObject.transform.position = spawnPos[randomPosIdx].position;
                    GameManager.Inst.monsterCount += 1;
                }

                yield return new WaitForSeconds(0.5f);
            }
        }
    }
}
