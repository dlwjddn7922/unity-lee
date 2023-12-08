using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : Singleton<SpawnController>
{
    float timer;
    float spawnTimer = 2f;
    float spawnCount = 0;
    int stage = 0;
    int maxSpawnCnt = 20;
    int spawnCnt;
    public int targetIndex;
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
        timer += Time.deltaTime;
        if (timer > spawnTimer && spawnCnt < maxSpawnCnt)
        {
            Monster mon = Instantiate(monster[stage], spawnPos);
            mon.MoveMonster(wayPoints);
            mon.name = "monster";

            timer = 0;
            spawnCnt++;
        }
    }

}
