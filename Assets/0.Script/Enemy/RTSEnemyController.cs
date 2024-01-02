using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTSEnemyController : Singleton<RTSEnemyController>
{
    [SerializeField] private SpawnController enemySpawn;
    [SerializeField] private List<EnemyContoller> selectedEnemyrList;
    [SerializeField] public List<EnemyContoller> enemyList = new List<EnemyContoller>();
    [SerializeField] public List<EnemyContoller> spawnerList { private set; get; }
    // Start is called before the first frame update
    void Start()
    {
        selectedEnemyrList = new List<EnemyContoller>();
    }
    void Update()
    {
    }
    /// <summary>
    /// 마우스 클릭으로 유닛을 선택할 때 호출
    /// </summary>
    public void ClickSelctPlayer(EnemyContoller newEnemy)
    {
        // 기존에 선택되어 있는 모든 유닛 해제
        DeselectAll();

        SelectPlayer(newEnemy);
    }
    /// <summary>
    /// Shift+마우스 클릭으로 유닛을 선택할 때 호출
    /// </summary>
    public void ShiftClickSelectPlayer(EnemyContoller newEnemy)
    {
        //기존에 선택되어 있는 유닛을 선택했을때
        if (selectedEnemyrList.Contains(newEnemy))
        {
            DeselectPlayer(newEnemy);
        }
        //새로운 유닛을 선택했을때
        else
        {
            SelectPlayer(newEnemy);
        }
    }
    /// <summary>
    /// 마우스 드래그로 유닛을 선택할 때 호출
    /// </summary>
    public void DragSelectPlayer(EnemyContoller newEnemy)
    {
        if (!selectedEnemyrList.Contains(newEnemy))
        {
            SelectPlayer(newEnemy);
        }
    }
    /// <summary>
    /// 모든 유닛의 선택을 해제할 때 호출
    /// </summary>
    public void DeselectAll()
    {
        for (int i = 0; i < selectedEnemyrList.Count; i++)
        {
            selectedEnemyrList[i].DeselectUnit();
        }
        selectedEnemyrList.Clear();
    }
    /// <summary>
    /// 매개변수로 반아온 newPlayer 선택 설정
    /// </summary>
    private void SelectPlayer(EnemyContoller newEnemy)
    {
        //플레이어가 선택되었을 때 호출하는 메소드
        newEnemy.SelectUnit();
        // 선택한 플레이어 정보를 리스트에 저장
        selectedEnemyrList.Add(newEnemy);
    }

    /// <summary>
    /// 매개변수로 받아온 newPlayer 선택 해제 설정
    /// </summary>
    private void DeselectPlayer(EnemyContoller newEnemy)
    {
        //플레이어가 해제되었을 때 호출하는 메소드
        newEnemy.DeselectUnit();
        // 선택한 플레이어 정보를 리스트에서 삭제
        selectedEnemyrList.Remove(newEnemy);
    }
    public void SpawnEnemy()
    {
        List<EnemyContoller> plist = enemySpawn.EnemySpawn();
        foreach (var item in plist)
        {
            enemyList.Add(item);
        }
    }
}
