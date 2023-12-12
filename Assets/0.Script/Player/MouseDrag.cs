using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour
{   //���콺�� �巡���� ������ ����ȭ�ϴ� Image UI�� RectTransform
    [SerializeField] private RectTransform dragRectangle;

    private Rect dragRect; // ���콺�� �巡�� �� ����
    private Vector2 start = Vector2.zero; //�巡�� ���� ��ġ
    private Vector2 end = Vector2.zero; //�巡�� ���� ��ġ

    private Camera mainCamera;
    private RTSPlayerController rTSPlayerController;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        rTSPlayerController = GetComponent<RTSPlayerController>();

        //start, end�� (0,0)�� ���·� �̹����� ũ�⸦(0,0)���� ������ ȭ�鿡 ������ �ʵ�����
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

            //���콺�� Ŭ���� ���·� �巡�� �ϴ� ���� �巡�� ������ �̹����� ǥ��
            DrawDragRectangle();
        }
        if(Input.GetMouseButtonUp(0))
        {
            //���콺 Ŭ���� ������ �� �巡�� ���� ���� �ִ� ���� ����
            CalculateDragRect();
            SelectPlayer();

            //���콺 Ŭ���� ������ �� �巡�� ������ ������ �ʵ���
            //start, end ��ġ�� (0,0)���� �����ϰ� �巡�� ������ �׸���
            start = end = Vector2.zero;
            DrawDragRectangle();

        }
    }
    void DrawDragRectangle()
    {
        //�巡�� ������ ��Ÿ���� Image UI�� ��ġ
        dragRectangle.position = (start + end) * 0.5f;
        //�巡�� ������ ��Ÿ���� Image UI�� ũ��
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
        //��� �÷��̾ �˻�
        foreach (PlayerController player in rTSPlayerController.playerList)
        {
            //�÷��̾��� ���� ��ǥ�� ȭ�� ��ǥ�� ��ȯ�� �巡�� ���� ���� �ִ��� �˻�
            if (dragRect.Contains(mainCamera.WorldToScreenPoint(player.transform.position)))
            {
                rTSPlayerController.DragSelectPlayer(player);              
            }
        }
    }
}
