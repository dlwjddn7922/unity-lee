using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnController : Singleton<SpawnController>
{
    float timer;
    float spawnTimer = 1f;
    float spawnCount = 0;
    int stage = 0;
    int maxSpawnCnt = 30;
    int spawnCnt;
    public int targetIndex;
    public bool isEnemySpawn = true;
    [SerializeField] private Monster[] monster;
    [SerializeField] public Transform spawnPos;
    [SerializeField] Transform[] wayPoints;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        EnemySpawn();

    }
    public List<EnemyContoller> EnemySpawn()
    {
        isEnemySpawn = true;
        List<EnemyContoller> unitList = new List<EnemyContoller>();
        timer += Time.deltaTime;
        if (timer > spawnTimer && spawnCnt < maxSpawnCnt)
        {
            Monster mon = Instantiate(monster[stage], spawnPos);
            mon.MoveMonster(wayPoints);
            mon.name = "monster";
            EnemyContoller enemy = mon.GetComponent<EnemyContoller>();

            timer = 0;
            spawnCnt++;
            unitList.Add(enemy);
        }
        return unitList;
    }
}
