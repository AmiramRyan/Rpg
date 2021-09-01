using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : Enemie
{

    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePos;

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        findDistance();
    }

    void findDistance()
    {
        float dis = Vector3.Distance(target.position, transform.position);
        if (dis <= chaseRadius && dis > attackRadius)
        {
            //chase the player
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}
