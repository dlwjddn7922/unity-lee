using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyContoller : MonoBehaviour
{
    [SerializeField] private GameObject unitMarker;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SelectUnit()
    {
        unitMarker.SetActive(true);
    }
    public void DeselectUnit()
    {
        unitMarker.SetActive(false);
    }
}
