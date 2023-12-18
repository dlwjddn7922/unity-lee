using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float scanRange;
    public LayerMask targetLayer;
    //public RaycastHit2D[] targets;
    //public Transform nearestTarget;
    [SerializeField] private Transform fireTrans;
    [SerializeField] private PlayerBullet bullet;
    private float fireTimer = float.MaxValue;
    private float fireDelayTime = 0.2f;

    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.red;
        Gizmos.DrawSphere(fireTrans.transform.position, scanRange);
    }
    void Update()
    {
        FireBullet();
    }

    public void FireBullet()
    {
        Collider2D[] findMonsters = Physics2D.OverlapCircleAll(transform.position, scanRange, targetLayer);
        float distance = float.MaxValue;
        Transform target = null;
        if (findMonsters.Length != 0)
        {
            foreach (var mon in findMonsters)
            {
                float dis = Vector2.Distance(transform.position, mon.transform.position);

                if (dis < distance)
                {
                    distance = dis;
                    target = mon.transform;
                }
            }
        }
        fireTimer += Time.deltaTime;
        if(target != null && fireTimer > fireDelayTime)
        {
            fireTimer = 0f;
            Vector2 vec = fireTrans.transform.position - target.transform.position;
            float angle = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;
            fireTrans.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);

            PlayerBullet b = Instantiate(bullet, fireTrans);
            b.SetTarget(target.transform);
            //b.transform.localPosition = Vector3.zero;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
    }
}
