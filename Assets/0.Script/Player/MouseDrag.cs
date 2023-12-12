using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour
{   //마우스로 드래그한 범위를 가시화하는 Image UI의 RectTransform
    [SerializeField] private RectTransform dragRectangle;

    private Rect dragRect; // 마우스로 드래그 한 범위
    private Vector2 start = Vector2.zero; //드래그 시작 위치
    private Vector2 end = Vector2.zero; //드래그 종료 위치

    private Camera mainCamera;
    private RTSPlayerController rTSPlayerController;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        rTSPlayerController = GetComponent<RTSPlayerController>();

        //start, end가 (0,0)인 상태로 이미지의 크기를(0,0)으로 설정해 화면에 보이지 않도록함
        DrawDragRectangle();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            start = Input.mousePosition;
            dragRect = new Rect();
        }
        if(Input.GetMouseButton(0))
        {
            end = Input.mousePosition;

            //마우스를 클릭한 상태로 드래그 하는 동안 드래그 범위를 이미지로 표현
            DrawDragRectangle();
        }
        if(Input.GetMouseButtonUp(0))
        {
            //마우스 클릭을 종료할 때 드래그 범위 내에 있는 유닛 선택
            CalculateDragRect();
            SelectPlayer();

            //마우스 클릭을 종료할 때 드래그 범위가 보이지 않도록
            //start, end 위치를 (0,0)으로 설정하고 드래그 범위를 그린다
            start = end = Vector2.zero;
            DrawDragRectangle();

        }
    }
    void DrawDragRectangle()
    {
        //드래그 범위를 나타내는 Image UI의 위치
        dragRectangle.position = (start + end) * 0.5f;
        //드래그 범위를 나타내는 Image UI의 크기
        dragRectangle.sizeDelta = new Vector2(Mathf.Abs(start.x - end.x), Mathf.Abs(start.y - end.y));
    }
    void CalculateDragRect()
    {
        if(Input.mousePosition.x < start.x)
        {
            dragRect.xMin = Input.mousePosition.x;
            dragRect.xMax = start.x;
        }
        else
        {
            dragRect.xMin = start.x;
            dragRect.xMax = Input.mousePosition.x;
        }
        if (Input.mousePosition.y < start.y)
        {
            dragRect.yMin = Input.mousePosition.y;
            dragRect.yMax = start.y;
        }
        else
        {
            dragRect.yMin = start.y;
            dragRect.yMax = Input.mousePosition.y;
        }
    }
    void SelectPlayer()
    {
        //모든 플레이어를 검사
        foreach (PlayerController player in rTSPlayerController.playerList)
        {
            //플레이어의 월드 좌표를 화면 좌표로 변환해 드래그 범위 내에 있는지 검사
            if (dragRect.Contains(mainCamera.WorldToScreenPoint(player.transform.position)))
            {
                rTSPlayerController.DragSelectPlayer(player);              
            }
        }
    }
}
