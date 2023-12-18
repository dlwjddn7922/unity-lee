using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{

    [HideInInspector] public float speed;
    [HideInInspector] public int power;
    private Transform target;

    void Start()
    {
        power = 2;
        speed = 25;
    }
    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        transform.position += (target.position - transform.position).normalized * Time.deltaTime * speed;
        //transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
    public void SetTarget(Transform target)
    {
        this.target = target;
        //vec = target.transform.position;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            //collision.GetComponent<Monster>().Hit(Power);
        }
    }
}
