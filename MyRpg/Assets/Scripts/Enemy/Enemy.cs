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
    public float speed;
    public int dmg;
    public string enemyName;
    public FloatValue maxHealth;
    public float hitPoints;
    public GameObject deathEffect;
    public float effectTimeToLive;

    private void Awake()
    {
        hitPoints = maxHealth.initialValue;
    }

    private void TakeDmg(float dmg)
    {
        hitPoints -= dmg;
        if (hitPoints <= 0)
        {
            //die animations
            playDeathEffect();
            //spawn loot randomly
            //destroy obj
            Debug.Log("I am dead :(");
            this.gameObject.SetActive(false); // for debugging 
        }
    }

    public void Knock(Rigidbody2D myRb, float knockTime , float dmg)
    {
        StartCoroutine(knockCo(myRb, knockTime));
        TakeDmg(dmg);
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

    public void playDeathEffect()
    {
        if(deathEffect != null)
        {
            Debug.Log("animtaionStart");
            GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(effect, effectTimeToLive);
            Debug.Log("animtaionEnd");
        }
    }
}
