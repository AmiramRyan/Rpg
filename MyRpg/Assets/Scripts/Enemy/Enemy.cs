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
    void Start()
    {

    }

    void Update()
    {
        
    }
}
