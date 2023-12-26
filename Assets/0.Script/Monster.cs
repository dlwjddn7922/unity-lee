using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Monster : Singleton<Monster>
{
    public int nextPosIndex = 0;
    SpriteRenderer sr;
    int hp;
    float speed = 1.5f;

    Transform[] target;
    // Start is called before the first frame update
    void Start()
    {
        hp = 30;
        sr = GetComponent<SpriteRenderer>();
        //transform.position = wayPoints[nextPosIndex].transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        if (target == null || target.Length == 0)
            return;

        Move();
    }
    public void MoveMonster(Transform[] target)
    {
        this.target = target;
    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, target[nextPosIndex].position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, target[nextPosIndex].transform.position) <= 0.1f)
        {
            nextPosIndex++;
        }
        if (nextPosIndex >= 4)
            nextPosIndex = 0;
        if (nextPosIndex == 3)
            sr.flipX = false;
        else if (nextPosIndex == 1)
            sr.flipX = true;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Hit();
        }
    }
    public void Hit()
    {
        hp -= Player.Instance.power;
        if(hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
