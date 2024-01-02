using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTSPlayerController : Singleton<RTSPlayerController>
{
    [SerializeField] private PlayerSpawn playerSpawn;
    [SerializeField] public List<PlayerController> selectedPlayerList;
    [SerializeField] public List<PlayerController> playerList = new List<PlayerController>();
    [SerializeField] public List<PlayerController> spawnerList { private set; get; }
    // Start is called before the first frame update
    void Start()
    {
        selectedPlayerList = new List<PlayerController>();
        spawnerList = playerSpawn.Spawner();
    }
    void Update()
    {
        
    }
    /// <summary>
    /// ���콺 Ŭ������ ������ ������ �� ȣ��
    /// </summary>
    public void ClickSelctPlayer(PlayerController newPlayer)
    {
        // ������ ���õǾ� �ִ� ��� ���� ����
        DeselectAll();

        SelectPlayer(newPlayer);
    }
    /// <summary>
    /// Shift+���콺 Ŭ������ ������ ������ �� ȣ��
    /// </summary>
    public void ShiftClickSelectPlayer(PlayerController newPlayer)
    {
        //������ ���õǾ� �ִ� ������ ����������
        if(selectedPlayerList.Contains(newPlayer))
        {
            DeselectPlayer(newPlayer);
        }
        //���ο� ������ ����������
        else
        {
            SelectPlayer(newPlayer);
        }
    }
    /// <summary>
    /// ���콺 �巡�׷� ������ ������ �� ȣ��
    /// </summary>
    public void DragSelectPlayer(PlayerController newPlayer)
    {
        if (!selectedPlayerList.Contains(newPlayer))
        {
            SelectPlayer(newPlayer);
        }
    }
    /// <summary>
    /// ���õ� ��� ������ �̵��� �� ȣ��
    /// </summary>
    public void MoveSelectedPlayer(Vector3 end)
    {
        for (int i = 0; i < selectedPlayerList.Count; i++)
        {
            selectedPlayerList[i].MoveTo(end);
        }
    }
    /// <summary>
    /// ��� ������ ������ ������ �� ȣ��
    /// </summary>
    public void DeselectAll()
    {
        for (int i = 0; i < selectedPlayerList.Count; i++)
        {
            selectedPlayerList[i].DeselectUnit();
        }
        selectedPlayerList.Clear();
    }
    /// <summary>
    /// �Ű������� �ݾƿ� newPlayer ���� ����
    /// </summary>
    public void SelectPlayer(PlayerController newPlayer)
    {
        //�÷��̾ ���õǾ��� �� ȣ���ϴ� �޼ҵ�
        newPlayer.SelectUnit();
        // ������ �÷��̾� ������ ����Ʈ�� ����
        selectedPlayerList.Add(newPlayer);
    }

    /// <summary>
    /// �Ű������� �޾ƿ� newPlayer ���� ���� ����
    /// </summary>
    private void DeselectPlayer(PlayerController newPlayer)
    {
        //�÷��̾ �����Ǿ��� �� ȣ���ϴ� �޼ҵ�
        newPlayer.DeselectUnit();
        // ������ �÷��̾� ������ ����Ʈ���� ����
        selectedPlayerList.Remove(newPlayer);
    }
    public void SpawnPlayer()
    {
        List<PlayerController> plist = playerSpawn.SpawnPlayer();
        foreach (var item in plist)
        {
            playerList.Add(item);
        }   
    }
}
