using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : Singleton<PlayerSpawn>
{
    [SerializeField] private GameObject[] unitPrefab;
    [SerializeField] private GameObject spanwerPrefab;
    [SerializeField] private int maxUnitCount;

    private Vector2 minsize = new Vector2(0, 0);
    private Vector2 maxsize = new Vector2(0, 0);
    enum PlayerRank
    {
        nomal= 0,
        rare,
        ancient,
        relic,
        transcription,
        legend,
        myth,
        god
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public List<PlayerController> SpawnPlayer()
    {
        List<PlayerController> unitList = new List<PlayerController>();

        Vector3 position = new Vector3(Random.Range(-1,-3),Random.Range(1,3),0);

        GameObject clone = Instantiate(unitPrefab[(int)PlayerRank.nomal], position, Quaternion.identity);
        PlayerController player = clone.GetComponent<PlayerController>();

        unitList.Add(player);
        
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
