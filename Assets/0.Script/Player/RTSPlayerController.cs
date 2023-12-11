using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTSPlayerController : MonoBehaviour
{
    [SerializeField] private PlayerSpawn playerSpawn;
    [SerializeField] private List<PlayerController> selectedPlayerList;
    [SerializeField] public List<PlayerController> playerList { private set; get; }
    // Start is called before the first frame update
    void Start()
    {
        selectedPlayerList = new List<PlayerController>();
        playerList = playerSpawn.SpawnPlayer();
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
    private void SelectPlayer(PlayerController newPlayer)
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
}
