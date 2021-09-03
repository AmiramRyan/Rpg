using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : Enemy
{
    private Rigidbody2D myRb;
    public Transform target;
    public float cheseRadius;
    public float attackRadius;
    public Transform homePosition;
    public Animator anim;
    private void ChangeState(EnemyState newState)
    {
        if (currentState != newState)
        {
            currentState = newState;
        }
    }

    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
    }


    void FixedUpdate()
    {
        CheckDist();
    }


    void CheckDist()
    {
        if(Vector3.Distance(target.position, transform.position) <= cheseRadius
            && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                changeAnimation(temp-transform.position);
                myRb.MovePosition(temp);
                ChangeState(EnemyState.walk);
                anim.SetBool("isAwake", true);
                
            }
        }
        else if (Vector3.Distance(target.position, transform.position) > cheseRadius)
        {
            anim.SetBool("isAwake", false);
        }
    }


    #region Animations
    private void changeAnimation(Vector2 direction)
    {
        if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
            {
                setFloatAnim(Vector2.right);
            }
            else if (direction.x < 0)
            {
                setFloatAnim(Vector2.left);
            }
        }
        else if(Mathf.Abs(direction.x) < Mathf.Abs(direction.y)) {
            if (direction.y > 0)
            {
                setFloatAnim(Vector2.up);
            }
            else if (direction.y < 0)
            {
                setFloatAnim(Vector2.down);
            }
        }
        /*direction = direction.normalized; working 
        anim.SetFloat("moveX", direction.x);
        anim.SetFloat("moveY", direction.y);*/
    }


    private void setFloatAnim(Vector2 direction)
    {
        anim.SetFloat("moveX", direction.x);
        anim.SetFloat("moveY", direction.y);
    }

    #endregion
}