using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : Singleton<PlayerController>
{
    [SerializeField] private GameObject unitMarker;
    [SerializeField] private NavMeshAgent nav;
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        nav.updateRotation = false;
        nav.updateUpAxis = false;
        //nav.speed = Player.Instance.speed;
    }

    // Update is called once per frame
    void Update()
    {
        ControlUnit();
    }
    public void SelectUnit()
    {
        unitMarker.SetActive(true);
    }
    public void DeselectUnit()
    {
        unitMarker.SetActive(false);
    }
    public void MoveTo(Vector3 end)
    {
        nav.SetDestination(end);
    }
    public void ControlUnit()
    {
        if (Input.GetKeyDown(KeyCode.H) || Input.GetKeyDown(KeyCode.S))
        {
            nav.ResetPath();
        }
    }
}
