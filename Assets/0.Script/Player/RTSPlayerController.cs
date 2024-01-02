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
    /// 마우스 클릭으로 유닛을 선택할 때 호출
    /// </summary>
    public void ClickSelctPlayer(PlayerController newPlayer)
    {
        // 기존에 선택되어 있는 모든 유닛 해제
        DeselectAll();

        SelectPlayer(newPlayer);
    }
    /// <summary>
    /// Shift+마우스 클릭으로 유닛을 선택할 때 호출
    /// </summary>
    public void ShiftClickSelectPlayer(PlayerController newPlayer)
    {
        //기존에 선택되어 있는 유닛을 선택했을때
        if(selectedPlayerList.Contains(newPlayer))
        {
            DeselectPlayer(newPlayer);
        }
        //새로운 유닛을 선택했을때
        else
        {
            SelectPlayer(newPlayer);
        }
    }
    /// <summary>
    /// 마우스 드래그로 유닛을 선택할 때 호출
    /// </summary>
    public void DragSelectPlayer(PlayerController newPlayer)
    {
        if (!selectedPlayerList.Contains(newPlayer))
        {
            SelectPlayer(newPlayer);
        }
    }
    /// <summary>
    /// 선택된 모든 유닛을 이동할 때 호출
    /// </summary>
    public void MoveSelectedPlayer(Vector3 end)
    {
        for (int i = 0; i < selectedPlayerList.Count; i++)
        {
            selectedPlayerList[i].MoveTo(end);
        }
    }
    /// <summary>
    /// 모든 유닛의 선택을 해제할 때 호출
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
    /// 매개변수로 반아온 newPlayer 선택 설정
    /// </summary>
    public void SelectPlayer(PlayerController newPlayer)
    {
        //플레이어가 선택되었을 때 호출하는 메소드
        newPlayer.SelectUnit();
        // 선택한 플레이어 정보를 리스트에 저장
        selectedPlayerList.Add(newPlayer);
    }

    /// <summary>
    /// 매개변수로 받아온 newPlayer 선택 해제 설정
    /// </summary>
    private void DeselectPlayer(PlayerController newPlayer)
    {
        //플레이어가 해제되었을 때 호출하는 메소드
        newPlayer.DeselectUnit();
        // 선택한 플레이어 정보를 리스트에서 삭제
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
