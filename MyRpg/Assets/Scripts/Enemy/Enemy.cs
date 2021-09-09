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

    [Header("Vars")]
    public float speed;
    public int dmg;
    public string enemyName;
    public float hitPoints;
    public FloatValue maxHealth;
    public Vector2 homePosition;

    [Header("Effects")]
    public GameObject deathEffect;
    public float effectTimeToLive;
    public LootTable lootTable;

    public Signal roomSignal;

    private void Awake()
    {
       // hitPoints = maxHealth.initialValue;
    }

    public virtual void OnEnable()
    {
        hitPoints = maxHealth.initialValue;
        this.transform.position = homePosition;
    }
    private void TakeDmg(float dmg)
    {
        hitPoints -= dmg;
        if (hitPoints <= 0)
        {
            //die animations
            playDeathEffect();
            //spawn loot randomly
            MakeItRain();
            //destroy obj
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
        if (roomSignal != null)
        {
            roomSignal.Rise();
        }
        if (deathEffect != null)
        {
            GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(effect, effectTimeToLive);
        }
    }

    public void MakeItRain()
    {
        if (lootTable != null) 
        {
            PowerUp gonnaSpawn = lootTable.RollForLoot();
            if (gonnaSpawn != null)
            {
                Instantiate(gonnaSpawn.gameObject, transform.position, Quaternion.identity);
            }
        }
    }
}
