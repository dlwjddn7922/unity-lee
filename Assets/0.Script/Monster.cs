using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Monster : Singleton<Monster>
{
    [SerializeField]  private Transform[] target;
    public int nextPosIndex = 0;
    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        //transform.position = wayPoints[nextPosIndex].transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        //MoveMonster();
    }

/*    public void NextPath(Transform[] wayPoints)
    {
        transform.position = Vector2.MoveTowards(transform.position, wayPoints[nextPosIndex].transform.position, 5f * Time.deltaTime);

        if (transform.position == wayPoints[nextPosIndex].transform.position)
            nextPosIndex++;

        if (nextPosIndex == 3)
            sr.flipX = false;
        else if (nextPosIndex == 1)
            sr.flipX = true;

        if (nextPosIndex == wayPoints.Length)
            nextPosIndex = 0;
        *//*Vector3[] wayPointsvec = new Vector3[wayPoints.Length];
        for (int i = 0; i < wayPoints.Length; i++)
        {
            wayPointsvec.SetValue(wayPoints[i].position, i);
        }
        transform.DOPath(wayPointsvec, 10f)
            .SetEase(Ease.Linear);*//*

    }*/
    public void MoveMonster(Transform[] target, int nextPosIndex)
    {
        transform.position = Vector3.MoveTowards(transform.position, target[nextPosIndex].position, 5f * Time.deltaTime);
        if (Vector3.Distance(transform.position, target[nextPosIndex].transform.position) < 0.1f)
        {
            nextPosIndex++;
        }
        if (nextPosIndex >= 4)
            nextPosIndex = 0;
    }


}
