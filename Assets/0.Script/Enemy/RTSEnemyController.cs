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
    /// ���콺 Ŭ������ ������ ������ �� ȣ��
    /// </summary>
    public void ClickSelctPlayer(EnemyContoller newEnemy)
    {
        // ������ ���õǾ� �ִ� ��� ���� ����
        DeselectAll();

        SelectPlayer(newEnemy);
    }
    /// <summary>
    /// Shift+���콺 Ŭ������ ������ ������ �� ȣ��
    /// </summary>
    public void ShiftClickSelectPlayer(EnemyContoller newEnemy)
    {
        //������ ���õǾ� �ִ� ������ ����������
        if (selectedEnemyrList.Contains(newEnemy))
        {
            DeselectPlayer(newEnemy);
        }
        //���ο� ������ ����������
        else
        {
            SelectPlayer(newEnemy);
        }
    }
    /// <summary>
    /// ���콺 �巡�׷� ������ ������ �� ȣ��
    /// </summary>
    public void DragSelectPlayer(EnemyContoller newEnemy)
    {
        if (!selectedEnemyrList.Contains(newEnemy))
        {
            SelectPlayer(newEnemy);
        }
    }
    /// <summary>
    /// ��� ������ ������ ������ �� ȣ��
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
    /// �Ű������� �ݾƿ� newPlayer ���� ����
    /// </summary>
    private void SelectPlayer(EnemyContoller newEnemy)
    {
        //�÷��̾ ���õǾ��� �� ȣ���ϴ� �޼ҵ�
        newEnemy.SelectUnit();
        // ������ �÷��̾� ������ ����Ʈ�� ����
        selectedEnemyrList.Add(newEnemy);
    }

    /// <summary>
    /// �Ű������� �޾ƿ� newPlayer ���� ���� ����
    /// </summary>
    private void DeselectPlayer(EnemyContoller newEnemy)
    {
        //�÷��̾ �����Ǿ��� �� ȣ���ϴ� �޼ҵ�
        newEnemy.DeselectUnit();
        // ������ �÷��̾� ������ ����Ʈ���� ����
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
