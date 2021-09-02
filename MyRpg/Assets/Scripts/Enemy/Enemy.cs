using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState{
    idle,
    walk,
    attack,
    stagger
}
public class Enemy : MonoBehaviour
{
    public EnemyState currentState;
    public float hitPoints;
    public float speed;
    public int dmg;
    public string enemyName;

    public void Knock(Rigidbody2D myRb, float knockTime)
    {
        StartCoroutine(knockCo(myRb, knockTime));
    }

    private IEnumerator knockCo(Rigidbody2D myRb, float knockTime)
    {
        if (myRb != null)
        {
            yield return new WaitForSeconds(knockTime);
            myRb.velocity = Vector2.zero;
            currentState = EnemyState.idle;
            myRb.velocity = Vector2.zero;
        }
    }
}
