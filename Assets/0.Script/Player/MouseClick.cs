using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour
{
    [SerializeField] private LayerMask layerPlayer;
    [SerializeField] private LayerMask layerGround;
    //[SerializeField] private Camera mainCamera;
    [SerializeField] private RTSPlayerController rTSPlayerController;

    float MaxDistance = 15f;
    Vector3 MousePostion, transPosition;
    Camera Camera;
    // Start is called before the first frame update
    void Start()
    {
        Camera = GetComponent<Camera>();
        rTSPlayerController = GetComponent<RTSPlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //���콺 ����Ŭ������ ���� ���� or ����
        if(Input.GetMouseButtonDown(0))
        {
            MousePostion = Input.mousePosition;
            transPosition = Camera.main.ScreenToWorldPoint(MousePostion);

            //������ �ε����� ������Ʈ�� ���� ��(=������ Ŭ��������)
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
            //������ �ε����� ������Ʈ�� ���� ��
            else
            {
                if(!Input.GetKey(KeyCode.LeftShift))
                {
                    rTSPlayerController.DeselectAll();
                }
            }
        }
        if(Input.GetMouseButtonDown(1))
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
