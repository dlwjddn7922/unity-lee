using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Spawn"))
        {
            Vector3 position = new Vector3((float)9.8, (float)6.45, 0);
            transform.position = position;
            PlayerController.Instance.MoveTo(position);
            RTSPlayerController.Instance.SpawnPlayer();
        }
    }
}
