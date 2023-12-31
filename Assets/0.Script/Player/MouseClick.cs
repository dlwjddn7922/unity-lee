using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour
{
    [SerializeField] private LayerMask layerPlayer;
    [SerializeField] private LayerMask layerEnemy;
    [SerializeField] private LayerMask layerGround;
    //[SerializeField] private Camera mainCamera;
    [SerializeField] private RTSPlayerController rTSPlayerController;
    [SerializeField] private RTSEnemyController rTSEnemyController;

    float MaxDistance = 15f;
    Vector3 MousePostion, transPosition;
    Camera Camera;
    // Start is called before the first frame update
    void Start()
    {
        Camera = GetComponent<Camera>();
        rTSPlayerController = GetComponent<RTSPlayerController>();
        rTSEnemyController = GetComponent<RTSEnemyController>();
    }

    // Update is called once per frame
    void Update()
    {
        //마우스 왼쪽클릭으로 유닛 선택 or 해제
        if(Input.GetMouseButtonDown(0))
        {
            MousePostion = Input.mousePosition;
            transPosition = Camera.main.ScreenToWorldPoint(MousePostion);

            //광선에 부딪히는 오브젝트가 있을 때(=유닛을 클릭했을때)
            RaycastHit2D hit = Physics2D.Raycast(transPosition, transform.forward, MaxDistance, layerPlayer);
            if(hit)
            {
                if (hit.transform.GetComponent<PlayerController>() == null) return;

                if(Input.GetKey(KeyCode.LeftShift))
                {                
                    rTSPlayerController.ShiftClickSelectPlayer(hit.transform.GetComponent<PlayerController>());
                }
                else
                {
                    rTSPlayerController.ClickSelctPlayer(hit.transform.GetComponent<PlayerController>());
                }
            }
            //광선에 부딛히는 오브젝트가 없을 때
            else
            {
                if(!Input.GetKey(KeyCode.LeftShift))
                {
                    rTSPlayerController.DeselectAll();
                }
            }
        }
        if (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.M))
        {
            //RaycastHit hit;
            MousePostion = Input.mousePosition;
            transPosition = Camera.main.ScreenToWorldPoint(MousePostion);

            RaycastHit2D hit = Physics2D.Raycast(transPosition,transform.forward,MaxDistance,layerGround);
            if (hit)
            {
                rTSPlayerController.MoveSelectedPlayer(hit.point);
            }
        }


    }
}
