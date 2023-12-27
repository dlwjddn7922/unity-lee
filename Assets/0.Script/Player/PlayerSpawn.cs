using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : Singleton<PlayerSpawn>
{
    [SerializeField] private GameObject[] unitPrefab;
    [SerializeField] private GameObject spanwerPrefab;
    [SerializeField] private Transform parent;

    private List<GameObject> players = new List<GameObject>();
    enum PlayerRank
    {
        nomal= 0,
        rare,
        ancient,
        relic,
        transcription,
        legend,
        epic,
        myth,
        god
    }
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] players = Resources.LoadAll<GameObject>("Player");
        foreach (var item in players)
        {
            this.players.Add(item);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public List<PlayerController> SpawnPlayer()
    {
        List<PlayerController> unitList = new List<PlayerController>();

        Vector3 position = new Vector3(Random.Range(-1,-3),Random.Range(1,3),0);
        float rand = Random.Range(1, 101);

        string spawnStr = rand < 50 ? "PlayerNomal" : rand < 83.1 ? "Playerrare" : rand < 93.3 ? "Playerancient" :
            rand < 98.4 ? "Playerrelic" : rand < 99.2 ? "Playertrans" : rand < 99.7 ? "Playerlegend" : rand < 99.9 ? "Playerepic" :
            rand < 99.98 ? "Playermyth" : "Playergod";
        for (int i = 0; i < players.Count; i++)
        {
            if(players[i].name == spawnStr)
            {
                GameObject clone = Instantiate(players[i], position, Quaternion.identity);
                clone.transform.SetParent(parent);
                PlayerController player = clone.GetComponent<PlayerController>();

                unitList.Add(player);
            }
        }    
        return unitList;
    }
    public List<PlayerController> Spawner()
    {
        List<PlayerController> unitList = new List<PlayerController>();

        Vector3 position = new Vector3((float)9.8, (float)6.45, 0);
        GameObject clone = Instantiate(spanwerPrefab, position, Quaternion.identity);
        PlayerController player = clone.GetComponent<PlayerController>();
        unitList.Add(player);

        return unitList;
    }
}
