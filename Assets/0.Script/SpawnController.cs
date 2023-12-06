using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    float timer;
    float spawnTimer = 2f;
    float spawnCount = 0;
    int stage = 0;
    int maxSpawnCnt = 20;
    int spawnCnt;
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
            Monster mon = Instantiate(monster[stage]);
            mon.NextPath(wayPoints);
            mon.transform.SetParent(spawnPos);
            mon.name = "monster";

            timer = 0;
            spawnCnt++;
        }
    }
}
