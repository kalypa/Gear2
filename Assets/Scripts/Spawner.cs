using Redcode.Pools;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> monsters = new();
    public List<Transform> spawnPos = new();
    void Start()
    {
        StartCoroutine(SpawnMonster(GameManager.Inst.currentStage));
    }
    IEnumerator SpawnMonster(int idx)
    {
        while (true)
        {
            if (GameManager.Inst.monsterCount < 20)
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
