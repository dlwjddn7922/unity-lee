using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Monster : MonoBehaviour
{

    int nextPosIndex = 0;
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
        //NextPath();
    }

    public void NextPath(Transform[] wayPoints)
    {
        /*transform.position = Vector2.MoveTowards(transform.position, wayPoints[nextPosIndex].transform.position,  5f * Time.deltaTime);

        if (transform.position == wayPoints[nextPosIndex].transform.position)
            nextPosIndex++;

        if (nextPosIndex == 3)
            sr.flipX = false;
        else if (nextPosIndex == 1)
            sr.flipX = true;

        if (nextPosIndex == wayPoints.Length)
            nextPosIndex = 0;   */
        Vector3[] wayPointsvec = new Vector3[wayPoints.Length];
        for (int i = 0; i < wayPoints.Length; i++)
        {
            wayPointsvec.SetValue(wayPoints[i].position, i);
        }
        transform.DOPath(wayPointsvec, 10f)
            .OnComplete(() => transform.DOPath(wayPointsvec, 10f));
    }

}
