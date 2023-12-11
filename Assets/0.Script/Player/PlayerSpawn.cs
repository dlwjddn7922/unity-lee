using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] private GameObject unitPrefab;
    [SerializeField] private int maxUnitCount;

    private Vector2 minsize = new Vector2(0, 0);
    private Vector2 maxsize = new Vector2(0, 0);
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
        List<PlayerController> unitList = new List<PlayerController>(maxUnitCount);

        for (int i = 0; i < maxUnitCount; i++)
        {
            Vector3 position = new Vector3(0,0,0);

            GameObject clone = Instantiate(unitPrefab, position, Quaternion.identity);
            PlayerController player = clone.GetComponent<PlayerController>();

            unitList.Add(player);
        }
        return unitList;
    }
}
